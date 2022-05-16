using PS.Template.AccessData.DbContexts;
using PS.Template.Aplication.Interfaces.Interface_Libro;
using PS.Template.Domain.Models;
using System.Collections;
using PS.Template.Aplication.Utils;

namespace PS.Template.AccessData.Queries
{
    public class QueryLibro : IQueryLibro
    {
        private readonly MyDbContext _context;

        public QueryLibro(MyDbContext cont)
        {
            _context = cont;
        }

        public Libros searchLibroByISBN(string isbn)
        {
            var libroExist = _context.libros.Where(L => L.ISBN == isbn).FirstOrDefault();
            return libroExist;
        }

        public Libros searchLibroByTitle(string titulo)
        {
            Libros libroExist = _context.libros.Where(X => X.Titulo == titulo).FirstOrDefault();
            return libroExist;
        }

        public List<Libros> listLibroByAuthor(string? autor,ArrayList array) {

            List<Libros> libroExist = new List<Libros>();
             
            foreach (Libros l in array)
            {
                if (l.Autor == autor)
                {
                    libroExist.Add(l);
                }
            }

            return libroExist;
        }

        public List<Libros> listLibroStock(){
            var libroExist = _context.libros.Where(X => X.Stock > 0).ToList();

            return libroExist;
        }

        public List<Libros> searchLibroByTitle(string titulo, ArrayList array) {

            List<Libros> libroExist = new List<Libros>();

            foreach (Libros l in array)
            {
                if (l.Titulo == titulo)
                {
                    libroExist.Add(l);
                }

            }

            return libroExist;

        }

        public List<Libros> searchaLibro() {

            var libro = _context.libros.ToList();
            return libro;
        }
    }
}
