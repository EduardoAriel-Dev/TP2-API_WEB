using PS.Template.Domain.Models;
using PS.Template.Aplication.Utils;
using System.Collections;

namespace PS.Template.Aplication.Interfaces.Interface_Libro
{
    public interface IQueryLibro
    {
        public Libros searchLibroByISBN(string isbn);
        public List<Libros> searchLibroByTitle(string titulo);
        public List<Libros> listLibroStock();
        public List<Libros> listLibroByAuthor(string? autor, List<Libros> list);
        public List<Libros> searchLibroByTitle(string titulo, List<Libros> array);
        public List<Libros> searchaLibro();
        public List<Libros> SearchLibroStock(int stock);
        public Libros SearchLibroStockId(string isbn, int stock);
        public List<Libros> SearchLibro(bool? stock, string autor, string titulo);
    }
}
