using oneparalyzer.ServiceCenter.UseCases.DTOs.Service;

namespace oneparalyzer.ServiceCenter.MVC.ViewModels
{
    public class ServiceVM
    {
        public IEnumerable<GetServiceDTO>? GetServicesDTO { get; set; }
        public AddServiceDTO? AddServiceDTO { get; set; }
        public RemoveServiceDTO RemoveServiceDTO { get; set; }
    }
}
