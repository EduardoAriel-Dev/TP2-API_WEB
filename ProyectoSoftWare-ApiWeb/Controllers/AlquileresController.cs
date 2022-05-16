using Microsoft.AspNetCore.Mvc;
using PS.Template.Aplication.Interfaces.interface_Alquiler;
using PS.Template.Domain.DTO;


namespace ProyectoSoftWare_ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquileresController : ControllerBase
    {
        private readonly IAlquilerService _alquilerService;

        public AlquileresController(IAlquilerService alquiler)
        {
            _alquilerService = alquiler;
        }


        [HttpPost]
        public async Task<IActionResult> createAlquiler([FromBody] DtoAlquiler dtoAlquiler)
        {
            var response  = _alquilerService.CreateAlquiler(dtoAlquiler);

            if (!response.succes)
            {
                return new JsonResult(response.content) { StatusCode = 404 };
            }
            return new JsonResult(response.content) { StatusCode = 201 };
        }


        /*[HttpGet("{id}")]
        public async Task<IActionResult> GetLibroByCliente(int id) { 
            
        
        }*/
    }
}
