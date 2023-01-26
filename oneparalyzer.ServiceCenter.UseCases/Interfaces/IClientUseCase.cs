using oneparalyzer.ServiceCenter.UseCases.DTOs.Client;


namespace oneparalyzer.ServiceCenter.UseCases.Interfaces
{
    public interface IClientUseCase
    {
        Task AddAsync(AddClientDTO clientDTO);
        Task UpdateAsync(UpdateClientDTO clientDTO);
        Task RemoveAsync(RemoveClientDTO clientDTO);
        IEnumerable<GetClientDTO> GetAll();
    }
}
