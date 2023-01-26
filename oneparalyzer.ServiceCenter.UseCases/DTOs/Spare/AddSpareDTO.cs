

namespace oneparalyzer.ServiceCenter.UseCases.DTOs.Spare
{
    public class AddSpareDTO
    {
        public string Title { get; set; } = null!;
        public string Device { get; set; } = null!;
        public string Details { get; set; } = null!;
        public decimal Price { get; set; }
        public uint Quantity { get; set; }
    }
}
