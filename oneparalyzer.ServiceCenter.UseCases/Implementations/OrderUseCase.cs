using Microsoft.EntityFrameworkCore;
using oneparalyzer.ServiceCenter.DataAccess.Interfaces;
using oneparalyzer.ServiceCenter.Domain.Entities;
using oneparalyzer.ServiceCenter.Domain.Enums;
using oneparalyzer.ServiceCenter.Domain.Exceptions;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Order;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Service;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Spare;
using oneparalyzer.ServiceCenter.UseCases.Interfaces;


namespace oneparalyzer.ServiceCenter.UseCases.Implementations
{
    public class OrderUseCase : IOrderUseCase
    {
        private readonly IApplicationDbContext _context;

        public OrderUseCase(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AddOrderDTO orderDTO)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == orderDTO.ClientId);
            var services = new List<Service>();
            var sparesOrder = new List<SpareOrder>();

            foreach (var serviceId in orderDTO.ServicesId)
            {
                var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == serviceId);
                services.Add(service);
            }
            var order = new Order(client, services);
            if (orderDTO.SparesOrder != null) 
            {
                foreach (var spareOrderItem in orderDTO.SparesOrder)
                {
                    var spare = await _context.Spares.FirstOrDefaultAsync(x => x.Id == spareOrderItem.SpareId);
                    var spareOrder = new SpareOrder(spare, spareOrderItem.Quantity);
                    sparesOrder.Add(spareOrder);
                }
                order.Spares = sparesOrder;
            }
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<GetOrderDTO> GetAll()
        {
            var orders = _context.Orders;
            var ordersDTO = ConvertToListOrderDTO(orders);
            return ordersDTO;
        }

        public IEnumerable<GetOrderDTO> GetAllActual()
        {
            var orders = _context.Orders.Where(x => 
                x.Status != OrderStatus.MoneyRefund || x.Status != OrderStatus.Confirm);
            var ordersDTO = ConvertToListOrderDTO(orders);
            return ordersDTO;
        }

        public async Task RemoveAsync(RemoveOrderDTO orderDTO)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderDTO.Id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Entity 'Order' where 'Id' = {orderDTO.Id} not found");
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task SetStatusMoneyRefundAsync(EditOrderStatusDTO orderDTO)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderDTO.Id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Entity 'Order' where 'Id' = {orderDTO.Id} not found");
            }
            order.StatusMoneyRefund();
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task SetStatusRejectionAsync(EditOrderStatusDTO orderDTO)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderDTO.Id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Entity 'Order' where 'Id' = {orderDTO.Id} not found");
            }
            order.StatusRejection();
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task SetStatusSuccessAsync(EditOrderStatusDTO orderDTO)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderDTO.Id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Entity 'Order' where 'Id' = {orderDTO.Id} not found");
            }
            order.StatusSuccess();
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(UpdateOrderDTO orderDTO)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<GetOrderDTO> ConvertToListOrderDTO(IEnumerable<Order> orders)
        {
            var ordersDTO = new List<GetOrderDTO>();
            var orderDTO = new GetOrderDTO();
            var serviceDTO = new GetServiceDTO();
            var spareDTO = new GetSpareDTO();

            foreach (var order in orders)
            {
                orderDTO.Id = order.Id;
                orderDTO.Client.FirstName = order.Client.FirstName;
                orderDTO.Client.FirstName = order.Client.LastName;
                orderDTO.Client.FirstName = order.Client.Surname;
                orderDTO.Client.FirstName = order.Client.Email;
                orderDTO.Client.FirstName = order.Client.PhoneNumber;

                foreach (var service in orderDTO.Services)
                {
                    serviceDTO.Id = service.Id;
                    serviceDTO.Price = service.Price;
                    serviceDTO.Title = service.Title;
                }

                if (orderDTO.Spares != null)
                {
                    foreach (var spare in orderDTO.Spares)
                    {
                        spareDTO.Id = spare.Id;
                        spareDTO.Price = spare.Price;
                        spareDTO.Device = spare.Device;
                        spareDTO.Quantity = spare.Quantity;
                        spareDTO.Details = spare.Details;
                        spareDTO.Title = spare.Title;
                    }
                }
                ordersDTO.Add(orderDTO);
            }
            return ordersDTO;
        }
    }
}
