using Microsoft.AspNetCore.Mvc;
using oneparalyzer.ServiceCenter.MVC.ViewModels;
using oneparalyzer.ServiceCenter.UseCases.Interfaces;

namespace oneparalyzer.ServiceCenter.MVC.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceUseCase _serviceUseCase;

        public ServiceController(IServiceUseCase serviceUseCase)
        {
            _serviceUseCase = serviceUseCase;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var serviceVM = new ServiceVM();
            serviceVM.GetServicesDTO = _serviceUseCase.GetAll();
            return View(serviceVM);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ServiceVM serviceVM)
        {
            await _serviceUseCase.AddAsync(serviceVM.AddServiceDTO);
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(ServiceVM serviceVM)
        {
            await _serviceUseCase.RemoveAsync(serviceVM.RemoveServiceDTO);
            serviceVM.GetServicesDTO = _serviceUseCase.GetAll();
            return View("GetAll", serviceVM);
        }


    }
}
