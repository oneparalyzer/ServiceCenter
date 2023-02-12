using Microsoft.AspNetCore.Mvc;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Service;
using oneparalyzer.ServiceCenter.UseCases.Interfaces;

namespace oneparalyzer.ServiceCenter.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceUseCase _serviceUseCase;

        public ServiceController(IServiceUseCase serviceUseCase)
        {
            _serviceUseCase = serviceUseCase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetServiceDTO>> GetAllServices()
        {
            try
            {
                var servicesDTO = _serviceUseCase.GetAll();
                return Ok(servicesDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> AddServiceAsync(AddServiceDTO serviceDTO)
        {
            try
            {
                await _serviceUseCase.AddAsync(serviceDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> RemoveServiceAsync(RemoveServiceDTO serviceDTO)
        {
            try
            {
                await _serviceUseCase.RemoveAsync(serviceDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult> UpdateServiceAsync(UpdateServiceDTO serviceDTO)
        {
            try
            {
                await _serviceUseCase.UpdateAsync(serviceDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
