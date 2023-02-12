using Microsoft.AspNetCore.Mvc;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Spare;
using oneparalyzer.ServiceCenter.UseCases.Interfaces;

namespace oneparalyzer.ServiceCenter.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SpareController : ControllerBase
    {
        private readonly ISpareUseCase _spareUseCase;

        public SpareController(ISpareUseCase spareUseCase)
        {
            _spareUseCase = spareUseCase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetSpareDTO>> GetAllSpare()
        {
            try
            {
                var sparesDTO = _spareUseCase.GetAll();
                return Ok(sparesDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> AddSpareAsync(AddSpareDTO spareDTO)
        {
            try
            {
                await _spareUseCase.AddAsync(spareDTO);
                ModelState.Clear();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult> RemoveSpareAsync(RemoveSpareDTO spareDTO)
        {
            try
            {
                await _spareUseCase.RemoveAsync(spareDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSpareAsync(UpdateSpareDTO spareDTO)
        {
            try
            {
                await _spareUseCase.UpdateAsync(spareDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
