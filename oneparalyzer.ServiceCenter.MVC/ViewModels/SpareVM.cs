using oneparalyzer.ServiceCenter.UseCases.DTOs.Spare;

namespace oneparalyzer.ServiceCenter.MVC.ViewModels
{
    public class SpareVM 
    {
        public IEnumerable<GetSpareDTO> GetSparesDTO { get; set; } = null!;
        public AddSpareDTO AddSpareDTO { get; set; } = null!;
        public RemoveSpareDTO RemoveSpareDTO { get; set; } = null!;
        public UpdateSpareDTO UpdateSpareDTO { get; set; } = null!;
    }
}
