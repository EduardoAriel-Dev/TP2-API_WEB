using PS.Template.AccessData.DbContexts;
using PS.Template.Aplication.Interfaces;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Models;
using System.Data;

namespace PS.Template.AccessData.Queries
{
    public class QueryCliente : IQueryCliente
    {
        private readonly MyDbContext _context;

        public QueryCliente(MyDbContext cont)
        {
            _context = cont;
        }

        public MyDbContext Get_context()
        {
            return _context;
        }

        public Cliente searchClientById(int cliente)
        {

            var listClient = _context.clientes.Find(cliente);

            return listClient;
        }

        public List<Cliente> searchClientByEmail(DtoGetCliente cliente)
        {
            List<Cliente> listClientEmail = _context.clientes.Where(X => X.Email == cliente.Email).ToList();

            return listClientEmail;
        }

        public List<Cliente> searchClientOthers(string? dni, string? nombre, string? apellido)
        {
            List<Cliente> listClient = _context.clientes.Where(X => X.DNI == dni || X.Nombre == nombre || X.Apellido == apellido).ToList();
            return listClient;
        }
    }
}
