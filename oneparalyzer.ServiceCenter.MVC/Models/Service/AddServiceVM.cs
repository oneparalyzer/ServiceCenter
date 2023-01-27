using System.ComponentModel.DataAnnotations;

namespace oneparalyzer.ServiceCenter.MVC.Models.Service
{
    public class AddServiceVM
    {
        [Required(ErrorMessage = "Укажите название услуги")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Укажите стоимость услуги")]
        public decimal Price { get; set; }
    }
}
