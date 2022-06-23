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

        public Cliente searchClientByEmail(DtoGetCliente cliente)
        {
            var listClientEmail = _context.clientes.Where(X => X.Email == cliente.Email).FirstOrDefault();

            return listClientEmail;
        }

        public List<Cliente> searchClientOthers(string? dni, string? nombre, string? apellido)
        {
            if (dni == null)
                {
                if (nombre != null && apellido != null)
                {
                    return _context.clientes.Where(x => x.Nombre == nombre && x.Apellido == apellido).ToList();
                }
                if (nombre==null && apellido == null)
                {
                    return _context.clientes.ToList();
                }
                return _context.clientes.Where(x => x.Nombre == nombre || x.Apellido == apellido).ToList();
            }
            if (nombre !=null && apellido != null)
            {
                return _context.clientes.Where(x => x.DNI == dni && x.Nombre == nombre && x.Apellido == apellido).ToList();
            }
            if (nombre != null || apellido != null)
            {
                return _context.clientes.Where(x => x.DNI == dni &&( x.Nombre == nombre || x.Apellido == apellido)).ToList();
            }
            return _context.clientes.Where(x => x.DNI == dni || x.Nombre == nombre || x.Apellido == apellido).ToList();
        }
        public Cliente SearchClientByDNI(string dni) {
            var dniExist = _context.clientes.Where(x => x.DNI == dni).FirstOrDefault();
            return dniExist;
        }
    }
}
