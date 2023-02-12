using oneparalyzer.ServiceCenter.UseCases.DTOs.Order;


namespace oneparalyzer.ServiceCenter.UseCases.Interfaces
{
    public interface IOrderUseCase
    {
        Task AddAsync(AddOrderDTO orderDTO);
        Task UpdateAsync(UpdateOrderDTO orderDTO);
        Task RemoveAsync(RemoveOrderDTO orderDTO);
        IEnumerable<GetOrderDTO> GetAll();
        IEnumerable<GetOrderDTO> GetAllActual();
        Task SetStatusSuccessAsync(EditOrderStatusDTO orderDTO);
        Task SetStatusRejectionAsync(EditOrderStatusDTO orderDTO);
        Task SetStatusMoneyRefundAsync(EditOrderStatusDTO orderDTO);
    }
}
