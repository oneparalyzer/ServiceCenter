using oneparalyzer.ServiceCenter.MVC.Models.Spare;

namespace oneparalyzer.ServiceCenter.MVC.ViewModels
{
    public class SpareVM
    {
        public AddSpareVM? AddSpareVM { get; set; }
        public RemoveSpareVM? RemoveSpareVM { get; set; }
        public UpdateSpareVM? UpdateSpareVM { get; set; }
        public IEnumerable<GetSpareVM>? GetSparesVM { get; set; }
    }
}
