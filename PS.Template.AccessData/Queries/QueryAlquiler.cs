using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Template.AccessData.DbContexts;
using PS.Template.Aplication.Interfaces.interface_Alquiler;
using PS.Template.Domain.Models;



namespace PS.Template.AccessData.Queries
{
    public class QueryAlquiler : IQueryAlquiler
    {
        private readonly MyDbContext _context;

        public QueryAlquiler(MyDbContext cont)
        {
            _context = cont;
        }

        public List<Alquileres> listAlquiler() {

            var clientExistAlquiler = _context.alquileres.ToList();

            return clientExistAlquiler;
        }

        public Alquileres getAlquileresByClientIsbn(int clienteId,string isbnId,int estadoAux) {
            Alquileres alquiler = _context.alquileres.Where(x => (x.IsbnId == isbnId && x.ClienteId == clienteId && x.EstadoDeAlquileresId == estadoAux)).FirstOrDefault();
            return alquiler;
        }

        public List<Alquileres> ListAlquilerByEstadoCliente(int estado,int cliente) {
            var listAlquiler = _context.alquileres.Where(X => X.EstadoDeAlquileresId == estado && X.ClienteId== cliente).ToList();
            return listAlquiler;
        }

        public List<Alquileres> ListaAlquiler() {
            var listAlquiler = _context.alquileres.ToList();
            return listAlquiler;
        }
    }
}
