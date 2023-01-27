using System.ComponentModel.DataAnnotations;

namespace oneparalyzer.ServiceCenter.MVC.Models.Spare
{
    public class AddSpareVM
    {
        [Required(ErrorMessage = "Укажите название комплектующего")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Укажите название устройства")]
        public string Device { get; set; } = null!;
        public string? Details { get; set; }

        [Required(ErrorMessage = "Укажите цену комплектующего")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Укажите колличество комплектующего")]
        public uint Quantity { get; set; }
    }
}
