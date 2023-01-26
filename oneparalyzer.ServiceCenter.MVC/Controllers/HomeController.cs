using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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