

using oneparalyzer.ServiceCenter.UseCases.DTOs.Client;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Service;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Spare;

namespace oneparalyzer.ServiceCenter.UseCases.DTOs.Order
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public GetClientDTO Client { get; set; } = null!;
        public List<GetServiceDTO> Services { get; set; } = null!;
        public List<GetSpareDTO>? Spares { get; set; }
    }
}
