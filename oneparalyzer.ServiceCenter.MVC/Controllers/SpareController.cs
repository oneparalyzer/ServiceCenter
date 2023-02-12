using Microsoft.AspNetCore.Mvc;
using oneparalyzer.ServiceCenter.MVC.ViewModels;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Spare;
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
            spareVM.GetSparesDTO = _spareUseCase.GetAll();
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
            try
            {
                if (ModelState.IsValid)
                {
                    AddSpareDTO spareDTO = spareVM.AddSpareDTO;
                    await _spareUseCase.AddAsync(spareDTO);
                    ModelState.Clear();
                }
                return View(spareVM);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Remove(SpareVM spareVM)
        {
            var spareDTO = spareVM.RemoveSpareDTO;
            await _spareUseCase.RemoveAsync(spareDTO);
            spareVM.GetSparesDTO = _spareUseCase.GetAll();
            return View("GetAll", spareVM);
        }
    }
}
