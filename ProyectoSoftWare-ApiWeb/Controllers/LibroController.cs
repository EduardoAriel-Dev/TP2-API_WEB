using Microsoft.AspNetCore.Mvc;
using PS.Template.Aplication.Interfaces.Interface_Libro;
using PS.Template.Aplication.Utils;

namespace ProyectoSoftWare_ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IlibroService _libroService;

        public LibroController(IlibroService client)
        {
            _libroService = client;
        }

        [HttpGet("{titulo}")]
        public async Task<IActionResult> GetLibro(string titulo)
        {
            try
            {
                var BookExist = _libroService.getLibroByTitle(titulo);
                if (!BookExist.succes)
                {
                    return new JsonResult(BookExist.content) { StatusCode = 400 };
                }
                return new JsonResult(BookExist.objects) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLibroOther([FromQuery] bool stock, [FromQuery] string? autor, [FromQuery] string? titulo) {

            try
            {
                var libroStock = _libroService.getLibroStock(stock);

                if (autor != null) {
                    libroStock = _libroService.getLibroByAuthor(autor, libroStock.arrList);
                }
                if (titulo != null)
                {
                    libroStock = _libroService.getLibroTitle(titulo, libroStock.arrList);
                }
                if (stock == false && autor == null && titulo == null)
                {
                    libroStock = _libroService.getLibro();
                }
                return new JsonResult(libroStock.arrList) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }


        }

        
    }
}
