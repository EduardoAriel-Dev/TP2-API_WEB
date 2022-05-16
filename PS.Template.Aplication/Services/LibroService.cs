using PS.Template.Aplication.Interfaces.Interface_Libro;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.Models;
using System.Collections;

namespace PS.Template.Aplication.Services
{
    public class LibroService : IlibroService
    {
        private readonly IQueryLibro _queryLibro;
        public LibroService(IQueryLibro query)
        {
            _queryLibro = query;
        }

        public Response getLibroByTitle(string titulo)
        {
            var response = new Response(true, "Libro Encontrado con Stock disponible");

            var query = _queryLibro.searchLibroByTitle(titulo);


            if (query == null)
            {
                response.succes = false;
                response.content = "No se encontro el libro ";
            }
            else
            {
                if (query.Stock > 0)
                {
                    response.objects = query;
                }
                else
                {
                    response.succes = false;
                    response.content = "Libro encontrado sin Stock disponible";
                }
            }

            return response;
        }

        public Response getLibroStock(bool stock) {

            var response = new Response(true,"Stock disponible");

            if (stock)
            {
                var query = _queryLibro.listLibroStock();
                response.arrList = new ArrayList();

                foreach (Libros l in query)
                {
                    if (l.Stock!=0)
                    {
                        response.arrList.Add(l);
                    }
                }
            }
            else
            {
                response.succes = false;
                response.content = "Sin filtro de Stock";
            }
           
            return response;
        }

        public Response getLibroByAuthor(string? autor,ArrayList array) {

            var response = new Response(true,"Autor Encontrado");

            var query = _queryLibro.listLibroByAuthor(autor,array);

            response.arrList = new ArrayList();

            if (query.Count != 0)
            {
                foreach (var l in query)
                {
                    response.arrList.Add(l);
                }
            }
            else
            {
                response.succes = false;
                response.content = "Autor No existene";
            }
            return response;
        }

        public Response getLibroTitle(string titulo,ArrayList array) {

            var response = new Response(true, "Titulo encontrado");

            var query = _queryLibro.searchLibroByTitle(titulo,array);

            response.arrList = new ArrayList();

            if (query.Count != 0)
            {
                foreach (var l in query)
                {
                    response.arrList.Add(l);
                }
            }
            else
            {
                response.succes = false;
                response.content = "Titulo No existene";
            }

            return response;
        }

        public Response getLibro() {

            var response = new Response(true,"Lista de libros");

            var libro = _queryLibro.searchaLibro();

            response.arrList = new ArrayList();
            foreach (Libros l in libro) {

                response.arrList.Add(l);
            }
            return response;
        }
    }
}
