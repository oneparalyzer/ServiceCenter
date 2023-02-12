using Microsoft.AspNetCore.Mvc;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Client;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Service;
using oneparalyzer.ServiceCenter.UseCases.Interfaces;

namespace oneparalyzer.ServiceCenter.Api.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientUseCase _clientUseCase;

        public ClientController(IClientUseCase clientUseCase)
        {
            _clientUseCase = clientUseCase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetClientDTO>> GetAllClients()
        {
            try
            {
                var clientsDTO = _clientUseCase.GetAll();
                return Ok(clientsDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddClientAsync(AddClientDTO clientDTO)
        {
            try
            {
                await _clientUseCase.AddAsync(clientDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> RemoveClientAsync(RemoveClientDTO clientDTO)
        {
            try
            {
                await _clientUseCase.RemoveAsync(clientDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateClientAsync(UpdateClientDTO clientDTO)
        {
            try
            {
                await _clientUseCase.UpdateAsync(clientDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
