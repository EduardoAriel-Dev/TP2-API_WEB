using Microsoft.AspNetCore.Mvc;
using PS.Template.Aplication.Interfaces;
using PS.Template.Domain.DTO;


namespace ProyectoSoftWare_ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService client)
        {
            _clienteService = client;
        }

        [HttpPost]
        public async Task<IActionResult> createCliente(DtoGetCliente id)
        {

            var response = _clienteService.createClient(id);

            if (!response.succes)
            {
                return new JsonResult(response.content) { StatusCode = 404 };
            }
            return new JsonResult(response.content) { StatusCode = 201 };
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteId(int id)
        {
            try
            {
                var ClientExist = _clienteService.getClienteById(id);
                if (!ClientExist.succes)
                {
                    return new JsonResult(ClientExist.content) { StatusCode = 400 };
                }
                return new JsonResult(ClientExist.objects) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> getClienteByothers([FromQuery] string? dni, [FromQuery] string? nombre, [FromQuery] string? apellido)
        {
            try
            {
                var clientExist = _clienteService.getClienteByOthers(dni, nombre, apellido);
                if (!clientExist.succes)
                {
                    return new JsonResult(clientExist.content) { StatusCode = 400 };
                }
                return new JsonResult(clientExist.objects) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }
    }
}
