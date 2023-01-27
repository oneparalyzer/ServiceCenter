using oneparalyzer.ServiceCenter.MVC.Models.Service;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Service;

namespace oneparalyzer.ServiceCenter.MVC.ViewModels
{
    public class ServiceVM
    {
        public IEnumerable<GetServiceVM>? GetServicesVM { get; set; }
        public AddServiceVM? AddServiceVM { get; set; }
        public RemoveServiceVM? RemoveServiceVM { get; set; }
        public UpdateServiceVM? UpdateServiceVM { get; set; }
    }
}
