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
        public List<Libros> searchLibroByTitle(string titulo)
        {
            var listLibroExist = (from l in _context.libros where l.Titulo.StartsWith(titulo) select l).ToList();
            return listLibroExist;
        }
        public List<Libros> listLibroByAuthor(string? autor,List<Libros> list) {

            var libroExistAuthor = _context.libros.Where(x => x.Autor == autor).ToList();

            list = libroExistAuthor;
            
            return list;
        }
        public List<Libros> listLibroStock(){
            var libroExist = _context.libros.Where(X => X.Stock > 0).ToList();

            return libroExist;
        }
        public List<Libros> searchLibroByTitle(string titulo, List<Libros> list) {

            var listExistTitle = _context.libros.Where(x => x.Titulo == titulo).ToList();

            list = listExistTitle;

            return list;
        }
        public List<Libros> searchaLibro() {
            var libro = _context.libros.ToList();
            return libro;
        }
        public List<Libros> SearchLibroStock(int stock) {
            var listLibroStock = _context.libros.Where(x => x.Stock == stock).ToList();
            return listLibroStock;
        }
        public Libros SearchLibroStockId(string isbn, int stock) {
            var libro = _context.libros.Where(x => x.ISBN == isbn && x.Stock >= stock && x.Stock > 0).FirstOrDefault();
            return libro;
        }
        public List<Libros> SearchLibro(bool? stock, string autor,string titulo) {

            if (stock==null)
            {
                return _context.libros.ToList();
            }
            if ((bool)stock)
            {
                if (autor!=null && titulo!=null)
                {
                    return _context.libros.Where(x => x.Titulo == titulo && x.Autor == autor && x.Stock > 0).ToList();
                }
                return _context.libros.Where(x => x.Stock>0 || (x.Titulo==titulo || x.Autor == autor)).ToList();
            }
            else
            {
                if (autor!=null && titulo!=null)
                {
                    return _context.libros.Where(x => x.Titulo == titulo && x.Autor == autor && x.Stock == 0).ToList();
                }
                if (autor != null || titulo != null)
                {
                    return _context.libros.Where(x => x.Stock == 0 && (x.Titulo == titulo || x.Autor == autor)).ToList();
                }
                return _context.libros.Where(x => x.Stock == 0).ToList();
            }
        }
    }
}
