using PS.Template.AccessData.DbContexts;
using PS.Template.Aplication.Interfaces.Interface_Estado;
using PS.Template.Domain.Models;

namespace PS.Template.AccessData.Queries
{
    public class QueryEstadoAlquiler : IQueryEstado
    {
        private readonly MyDbContext _context;

        public QueryEstadoAlquiler(MyDbContext cont)
        {
            _context = cont;
        }

        public EstadoDeAlquileres searchEstadoAlquiler(int estado)
        {
            var Estado = (EstadoDeAlquileres)_context.estadoDeAlquileres.Where(X => X.EstadoId == estado);
            return Estado;
        }
    }
}
