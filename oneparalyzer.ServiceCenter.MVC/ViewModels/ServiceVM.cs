using oneparalyzer.ServiceCenter.UseCases.DTOs.Service;


namespace oneparalyzer.ServiceCenter.MVC.ViewModels
{
    public class ServiceVM 
    {
        public IEnumerable<GetServiceDTO> GetServicesDTO { get; set; } = null!;
        public AddServiceDTO AddServiceDTO { get; set; } = null!;
        public RemoveServiceDTO RemoveServiceDTO { get; set; } = null!;
        public UpdateServiceDTO UpdateServiceDTO { get; set; } = null!;
    }
}
