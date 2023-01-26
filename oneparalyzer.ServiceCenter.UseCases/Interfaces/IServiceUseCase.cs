

using oneparalyzer.ServiceCenter.UseCases.DTOs.Service;

namespace oneparalyzer.ServiceCenter.UseCases.Interfaces
{
    public interface IServiceUseCase
    {
        Task AddAsync(AddServiceDTO serviceDTO);
        Task UpdateAsync(UpdateServiceDTO serviceDTO);
        Task RemoveAsync(RemoveServiceDTO serviceDTO);
        IEnumerable<GetServiceDTO> GetAll();
    }
}
