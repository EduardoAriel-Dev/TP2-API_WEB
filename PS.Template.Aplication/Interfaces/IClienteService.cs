using PS.Template.Aplication.Utils;
using PS.Template.Domain.DTO;

namespace PS.Template.Aplication.Interfaces
{
    public interface IClienteService
    {
        public Response createClient(DtoGetCliente cliente);
        public Response getClienteById(int cliente);

        public Response getClienteByOthers(string dni, string nombre, string apellido);
    }
}
