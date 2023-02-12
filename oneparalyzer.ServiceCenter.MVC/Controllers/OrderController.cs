using Microsoft.AspNetCore.Mvc;
using oneparalyzer.ServiceCenter.UseCases.Interfaces;

namespace oneparalyzer.ServiceCenter.MVC.Controllers
{
    public class OrderController : Controller
    {
        private IOrderUseCase _orderUseCase;

        public OrderController(IOrderUseCase orderUseCase)
        {
            _orderUseCase = orderUseCase;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
