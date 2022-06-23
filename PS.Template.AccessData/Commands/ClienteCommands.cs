using PS.Template.AccessData.DbContexts;
using PS.Template.Aplication.Interfaces;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Models;


namespace PS.Template.AccessData.Commands
{
    public class ClienteCommands : IClienteCommand
    {
        private readonly MyDbContext _context;

        public ClienteCommands(MyDbContext cont)
        {
            _context = cont;
        }

        public Response InsertClientDataBase(DtoGetCliente cliente)
        {
            var response = new Response(true, "El cliente se ha guaraddo correctamente");
            try
            {
                var client = new Cliente();
                {
                    client.Nombre = cliente.Nombre;
                    client.Apellido = cliente.Apellido;
                    client.Email = cliente.Email;
                    client.DNI = cliente.DNI;
                }
                _context.clientes.Add(client);
                _context.SaveChanges();
                response.objects = client;
            }
            catch (Exception e)
            {
                return new Response(false, "Internal server error");
            }
            return response;
        }
    }
}
