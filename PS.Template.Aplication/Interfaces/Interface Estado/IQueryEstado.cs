using PS.Template.Domain.Models;

namespace PS.Template.Aplication.Interfaces.Interface_Estado
{
    public interface IQueryEstado
    {
        public EstadoDeAlquileres searchEstadoAlquiler(int estado);
    }
}
