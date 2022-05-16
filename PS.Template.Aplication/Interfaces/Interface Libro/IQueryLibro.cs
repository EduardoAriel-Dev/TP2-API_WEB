using PS.Template.Domain.Models;
using PS.Template.Aplication.Utils;
using System.Collections;

namespace PS.Template.Aplication.Interfaces.Interface_Libro
{
    public interface IQueryLibro
    {
        public Libros searchLibroByISBN(string isbn);
        public Libros searchLibroByTitle(string titulo);
        public List<Libros> listLibroStock();
        public List<Libros> listLibroByAuthor(string? autor, ArrayList array);
        public List<Libros> searchLibroByTitle(string titulo, ArrayList array);
        public List<Libros> searchaLibro();
    }
}
