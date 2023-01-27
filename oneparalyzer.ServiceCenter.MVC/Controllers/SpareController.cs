using Microsoft.AspNetCore.Mvc;
using oneparalyzer.ServiceCenter.Domain.Entities;
using oneparalyzer.ServiceCenter.MVC.Models.Spare;
using oneparalyzer.ServiceCenter.MVC.ViewModels;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Service;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Spare;
using oneparalyzer.ServiceCenter.UseCases.Implementations;
using oneparalyzer.ServiceCenter.UseCases.Interfaces;

namespace oneparalyzer.ServiceCenter.MVC.Controllers
{
    public class SpareController : Controller
    {
        private readonly ISpareUseCase _spareUseCase;

        public SpareController(ISpareUseCase spareUseCase)
        {
            _spareUseCase = spareUseCase;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var spareVM = new SpareVM();
            spareVM.GetSparesVM = ConvertToListSparesVM(_spareUseCase.GetAll());
            return View(spareVM);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SpareVM spareVM)
        {
            if (ModelState.IsValid)
            {
                var spareDTO = new AddSpareDTO
                {
                    Price = spareVM.AddSpareVM.Price,
                    Title = spareVM.AddSpareVM.Title,
                    Details = spareVM.AddSpareVM.Details,
                    Device = spareVM.AddSpareVM.Device,
                    Quantity = spareVM.AddSpareVM.Quantity
                };
                await _spareUseCase.AddAsync(spareDTO);
                ModelState.Clear();
            }
            return View();
        }

        private IEnumerable<GetSpareVM> ConvertToListSparesVM(IEnumerable<GetSpareDTO> sparesDTO)
        {
            var sparesVM = new List<GetSpareVM>();

            foreach (var spareDTO in sparesDTO)
            {
                var spareVM = new GetSpareVM
                {
                    Id= spareDTO.Id,
                    Details= spareDTO.Details,
                    Device = spareDTO.Device,
                    Price = spareDTO.Price,
                    Quantity = spareDTO.Quantity,
                    Title = spareDTO.Title
                };
                sparesVM.Add(spareVM);
            }
            return sparesVM;
        }
    }
}
