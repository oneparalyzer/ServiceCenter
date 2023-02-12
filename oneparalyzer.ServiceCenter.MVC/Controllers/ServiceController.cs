using Microsoft.AspNetCore.Mvc;
using oneparalyzer.ServiceCenter.MVC.ViewModels;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Service;
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
            try
            {
                if (ModelState.IsValid)
                {
                    AddServiceDTO serviceDTO = serviceVM.AddServiceDTO;
                    await _serviceUseCase.AddAsync(serviceDTO);
                    ModelState.Clear();
                }
                return View(serviceVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(serviceVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(ServiceVM serviceVM)
        {
            var serviceDTO = serviceVM.RemoveServiceDTO;
            await _serviceUseCase.RemoveAsync(serviceDTO);
            serviceVM.GetServicesDTO = _serviceUseCase.GetAll();
            return View("GetAll", serviceVM);
        }
    }
}
