using PS.Template.Aplication.Interfaces.Interface_Libro;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.Models;
using System.Collections;
using PS.Template.Domain.DTO;

namespace PS.Template.Aplication.Services
{
    public class LibroService : IlibroService
    {
        private readonly IQueryLibro _queryLibro;
        public LibroService(IQueryLibro query)
        {
            _queryLibro = query;
        }
        public Response filtersLibro(bool? stock, string? autor, string? titulo) 
        {
            var response = new Response(true, "Lista de Libros");
            response.statuscode = 200;
            var query = _queryLibro.SearchLibro(stock,autor,titulo);
            ArrayList array = new ArrayList();
            if (query.Count==0)
            {
                response.succes = false;
                response.statuscode = 400;
                response.content = "Libro no encontrado";
            }
            else
            {
                response.objects = query;
            }
            return response;
        }
        public Response GetLibroById(string ISBN) {
            var response = new Response(true,"Libro Encontrado");
            response.statuscode = 200;
            var query = _queryLibro.searchLibroByISBN(ISBN);
            if (query == null)
            {
                response.succes = false;
                response.content = "ISBN del libro no encontrado";
                response.statuscode = 400;
            }
            else
            {
                response.objects = query;
            }
            return response;
        }
        public Response HeadLibroByStockId(string isbn , int stock) {
            var response = new Response(true, "");
            response.statuscode = 200;
            var query = _queryLibro.SearchLibroStockId(isbn, stock);
            if (query == null)
            {
                response.succes = false;
                response.statuscode = 400;
            }
            return response;
        }
        public Response GetLibroByTitle(string title) {
            var response = new Response(true,"Libro encontrado");
            response.statuscode = 200;
            ArrayList array = new ArrayList();
            var query = _queryLibro.searchLibroByTitle(title);
            if (query == null)
            {
                response.succes = false;
                response.content = "Titulo no encontrado";
                response.statuscode = 400;
            }
            else {
                foreach(Libros libro in query)
                {
                    array.Add(libro);
                }
                response.arrList = array;
            }
            return response;
        }
    }
}
