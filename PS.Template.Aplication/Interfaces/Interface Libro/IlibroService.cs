using PS.Template.Aplication.Utils;
using System.Collections;

namespace PS.Template.Aplication.Interfaces.Interface_Libro
{
    public interface IlibroService
    {
        public Response filtersLibro(bool? stock, string? autor, string? titulo);
        public Response GetLibroById(string ISBN);
        public Response HeadLibroByStockId(string isbn, int stock);
        public Response GetLibroByTitle(string title);
    }
}
