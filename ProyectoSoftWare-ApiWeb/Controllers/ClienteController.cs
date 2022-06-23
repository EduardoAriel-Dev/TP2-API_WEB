using Microsoft.AspNetCore.Mvc;
using PS.Template.Aplication.Interfaces;
using PS.Template.Domain.DTO;


namespace ProyectoSoftWare_ApiWeb.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService client)
        {
            _clienteService = client;
        }

        [HttpPost]
        public IActionResult CreateCliente(DtoGetCliente id)
        {

            var response = _clienteService.createClient(id);

            if (!response.succes)
            {
                return new JsonResult(new { error = response.content }) { StatusCode = response.statuscode };
            }
            return new JsonResult(new {Message = response.content , objeto = response.objects }) { StatusCode = response.statuscode };
        }
        [HttpGet("{id}")]
        public IActionResult GetClienteId(int id)
        {
            try
            {
                var response = _clienteService.getClienteById(id);
                if (!response.succes)
                {
                    return new JsonResult(new {Error = response.content }) { StatusCode = response.statuscode };
                }
                return new JsonResult(new { Objeto = response.objects, Message = response.content }) { StatusCode = response.statuscode };
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        [HttpGet]
        public IActionResult GetClienteByothers([FromQuery] string? dni, [FromQuery] string? nombre, [FromQuery] string? apellido)
        {
            try
            {
                var response = _clienteService.getClienteByOthers(dni, nombre, apellido);
                if (!response.succes)
                {
                    return new JsonResult(new {Error = response.content }) { StatusCode = response.statuscode };
                }
                return new JsonResult(new {Objeto = response.objects, Message = response.content }) { StatusCode = response.statuscode };
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }
        [HttpGet("/alquiler/{cliente}")]
        public IActionResult GetAlquilerByCliente(int cliente,[FromQuery] int estado) {
            try
            {
                var response = _clienteService.GetAlquilerByEstado(cliente,estado);
                if (!response.succes)
                {
                    return new JsonResult(new { Error = response.content }) { StatusCode = response.statuscode };
                }
                return new JsonResult(new { Objeto = response.arrList, Message = response.content }) { StatusCode = response.statuscode };
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
