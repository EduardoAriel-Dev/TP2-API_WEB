using PS.Template.Domain.DTO;
using PS.Template.Domain.Models;

namespace PS.Template.Aplication.Interfaces
{
    public interface IQueryCliente
    {
        public Cliente searchClientById(int cliente);
        public List<Cliente> searchClientByEmail(DtoGetCliente cliente);
        public List<Cliente> searchClientOthers(string? dni, string? nombre, string? apellido);

    }
}
