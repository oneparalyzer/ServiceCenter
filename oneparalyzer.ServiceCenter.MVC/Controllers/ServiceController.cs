using Microsoft.AspNetCore.Mvc;
using oneparalyzer.ServiceCenter.MVC.Models.Service;
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
            serviceVM.GetServicesVM = ConvertToListServicesVM(_serviceUseCase.GetAll());
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
            if (ModelState.IsValid)
            {
                var serviceDTO = new AddServiceDTO
                {
                    Price = serviceVM.AddServiceVM.Price,
                    Title = serviceVM.AddServiceVM.Title
                };
                await _serviceUseCase.AddAsync(serviceDTO);
                ModelState.Clear();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(ServiceVM serviceVM)
        {
            var removeServiceDTO = new RemoveServiceDTO
            {
                Id = serviceVM.RemoveServiceVM.Id
            };
            await _serviceUseCase.RemoveAsync(removeServiceDTO);
            serviceVM.GetServicesVM = ConvertToListServicesVM(_serviceUseCase.GetAll());
            return View("GetAll", serviceVM);
        }

        private IEnumerable<GetServiceVM> ConvertToListServicesVM(IEnumerable<GetServiceDTO> servicesDTO)
        {
            var servicesVM = new List<GetServiceVM>();
            

            foreach (var serviceDTO in servicesDTO)
            {
                var serviceVM = new GetServiceVM
                {
                    Id = serviceDTO.Id,
                    Title = serviceDTO.Title,
                    Price = serviceDTO.Price
                };
                servicesVM.Add(serviceVM);
            }
            return servicesVM;
        }


    }
}
