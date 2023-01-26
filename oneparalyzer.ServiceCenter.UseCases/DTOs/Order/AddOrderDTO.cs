

namespace oneparalyzer.ServiceCenter.UseCases.DTOs.Order
{
    public class AddOrderDTO
    {
        public int ClientId { get; set; }
        public List<int> ServicesId { get; set; } = null!;
        public List<SpareOrderDTO>? SparesOrder { get; set; }
    }
}
