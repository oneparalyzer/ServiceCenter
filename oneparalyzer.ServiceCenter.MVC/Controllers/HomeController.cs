using Microsoft.AspNetCore.Mvc;


namespace oneparalyzer.ServiceCenter.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}