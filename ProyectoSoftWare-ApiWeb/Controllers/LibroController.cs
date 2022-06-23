using Microsoft.AspNetCore.Mvc;
using PS.Template.Aplication.Interfaces.Interface_Libro;
using PS.Template.Aplication.Utils;

namespace ProyectoSoftWare_ApiWeb.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IlibroService _libroService;

        public LibroController(IlibroService client)
        {
            _libroService = client;
        }

        [HttpGet("libros/{id}")]
        public IActionResult GetLibro(string id)
            {
            try
            {
                var response = _libroService.GetLibroById(id);
                if (!response.succes)
                {
                    return new JsonResult(new { Error = response.content }) { StatusCode = response.statuscode };
                }
                return new JsonResult(new { Message = response.content ,Objeto = response.objects}) { StatusCode = response.statuscode };
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        [HttpGet("libros")]
        public IActionResult GetLibroOther([FromQuery] bool? stock, [FromQuery] string? autor, [FromQuery] string? titulo) {
            try
            {
                var response = _libroService.filtersLibro(stock,autor,titulo);

                if (!response.succes)
                {
                    return new JsonResult(new { Message = response.content}) { StatusCode = response.statuscode};
                }
                return new JsonResult(new { Message = response.content, objeto = response.objects}) { StatusCode = response.statuscode};
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        [HttpHead("libros/{id}")]
        public IActionResult HeadLibroStock(string id, [FromQuery] int stock) {
            try
            {
                var response = _libroService.HeadLibroByStockId(id,stock);
                if (!response.succes)
                {
                    return new JsonResult(new {Error = response.succes}) { StatusCode = response.statuscode };
                }
                return new JsonResult(new {Message = response.succes}) { StatusCode = response.statuscode };
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }
        [HttpGet("libro/{titulo}/")]
        public IActionResult GetLibroByTitle(string titulo) {
            try
            {
                var response = _libroService.GetLibroByTitle(titulo);

                if (!response.succes)
                {
                    return new JsonResult(new { error = response.content}) { StatusCode = response.statuscode };
                }
                return new JsonResult(new { Message = response.content, List = response.arrList }) { StatusCode = response.statuscode };
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }
    }
}
