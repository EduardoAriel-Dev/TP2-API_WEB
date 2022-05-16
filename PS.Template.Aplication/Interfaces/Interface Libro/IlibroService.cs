using PS.Template.Aplication.Utils;
using System.Collections;

namespace PS.Template.Aplication.Interfaces.Interface_Libro
{
    public interface IlibroService
    {
        public Response getLibroByTitle(string titulo);
        public Response getLibroStock(bool stock);
        public Response getLibroByAuthor(string? autor, ArrayList array);
        public Response getLibroTitle(string titulo, ArrayList array);
        public Response getLibro();
    }
}
