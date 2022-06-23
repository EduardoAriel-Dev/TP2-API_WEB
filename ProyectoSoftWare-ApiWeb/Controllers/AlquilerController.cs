using Microsoft.AspNetCore.Mvc;
using PS.Template.Aplication.Interfaces.interface_Alquiler;
using PS.Template.Aplication.Interfaces.Interface_Libro;
using PS.Template.Domain.DTO;
using System.Collections;
using PS.Template.Domain.Models;

namespace ProyectoSoftWare_ApiWeb.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AlquileresController : ControllerBase
    {
        private readonly IAlquilerService _alquilerService;
        private readonly IlibroService _libroService;

        public AlquileresController(IAlquilerService alquiler,IlibroService libro)
        {
            _alquilerService = alquiler;
            _libroService = libro;
        }
        [HttpPost("alquiler")]
        public IActionResult createAlquiler(DtoAlquiler dtoAlquiler)
        {
            var response = _alquilerService.CreateAlquiler(dtoAlquiler);
            Alquileres alquiler = (Alquileres)response.objects;
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.statuscode };
            }
            return new JsonResult(new { Message = response.content,
                IdCliente = alquiler.ClienteId,
                Isbn = alquiler.IsbnId,
                FechaDeAlquiler = alquiler.FechaAlquiler,
                FechaDeDevolucion = alquiler.FechaDevolucion,
                Stock = alquiler.Isbn.Stock
            }) { StatusCode = response.statuscode };
        }
        [HttpGet("alquiler/cliente/{id}")]
        public IActionResult GetLibroByCliente(int id) {
            try
            {
                var response = _alquilerService.searchLibroByClient(id);

                ArrayList array = new ArrayList();
                if (!response.succes)
                {
                    return new JsonResult(new { message = response.content }) { StatusCode = response.statuscode };
                }            
                return new JsonResult(new {objeto = response.objects }) { StatusCode = response.statuscode };
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        [HttpPut("alquiler")]
        public IActionResult putAlquiler([FromBody] DtoReserva dtoReserva) {

            var response = _alquilerService.putAlquiler(dtoReserva);

            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.statuscode };
            }
            return new JsonResult(new { Message = response.content }) { StatusCode = response.statuscode };
        }
        [HttpGet("alquiler/")]
        public IActionResult GetLibroByAlquiler([FromQuery] int estado) {
            try
            {
                var response = _alquilerService.GetAlquilerByEstado(estado);
                ArrayList array = new ArrayList();
                if (!response.succes)
                {
                    return new JsonResult(new { list = response.arrList }) { StatusCode = response.statuscode };
                }             
                return new JsonResult(new {Message = response.content , list = response.arrList }) { StatusCode = response.statuscode };

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }


        }



    }
}
