using oneparalyzer.ServiceCenter.Domain.Enums;

namespace oneparalyzer.ServiceCenter.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public OrderStatus Status { get; private set; }
        public Client Client { get; private set; } 
        public List<Service> Services { get; private set; } 
        public List<SpareOrder> Spares { get; set; } 

        public Order(Client client, List<Service> service)
        {
            Client = client;
            Services = service;
            Spares = new List<SpareOrder>();
        }

        public void Create()
        {
            Status = OrderStatus.InProgress;
            foreach (var spareOrder in SparesOrders)
            {
                spareOrder.Spare.Reduce(spareOrder.Quantity);
            }
        }

        public decimal CalculatePrice()
        {
            decimal price = 0;
            foreach (var serviceOrder in ServicesOrders)
            {
                price += serviceOrder.Service.Price;
            }
            foreach (var spareOrder in SparesOrders)
            {
                price += spareOrder.Spare.Price * spareOrder.Quantity;
            }
            return price;
        }

        public void StatusSuccess()
        {
            Status = OrderStatus.Success;
        }

        public void StatusRejection()
        {
            Status = OrderStatus.Rejection;
        }

        public void StatusMoneyRefund()
        {
            Status = OrderStatus.MoneyRefund;
        }

    }
}
