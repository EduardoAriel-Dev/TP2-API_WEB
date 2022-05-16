using PS.Template.Aplication.Utils;
using PS.Template.Domain.DTO;

namespace PS.Template.Aplication.Interfaces
{
    public interface IClienteCommand
    {
        public Response InsertClientDataBase(DtoGetCliente cliente);
    }
}
