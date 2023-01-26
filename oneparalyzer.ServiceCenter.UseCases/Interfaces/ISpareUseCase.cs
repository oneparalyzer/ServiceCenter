using oneparalyzer.ServiceCenter.UseCases.DTOs.Spare;


namespace oneparalyzer.ServiceCenter.UseCases.Interfaces
{
    public interface ISpareUseCase
    {
        Task AddAsync(AddSpareDTO spareDTO);
        Task UpdateAsync(UpdateSpareDTO spareDTO);
        Task RemoveAsync(RemoveSpareDTO spareDTO);
        IEnumerable<GetSpareDTO> GetAll();
    }
}
