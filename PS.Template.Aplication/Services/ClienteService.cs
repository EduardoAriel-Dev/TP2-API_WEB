using PS.Template.Aplication.Interfaces;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.DTO;


namespace PS.Template.Aplication.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteCommand _clienteCommand;
        private readonly IQueryCliente _queryCliente;
        public ClienteService(IClienteCommand com, IQueryCliente query)
        {
            _clienteCommand = com;
            _queryCliente = query;
        }
        public Response createClient(DtoGetCliente cliente)
        {
            var response = new Response(true, "El cliente se ha Creado Correctamente");

            var fieldsValid = this.validatedFields(cliente);
            if (!fieldsValid.succes)
            {
                response.content = fieldsValid.content;
                response.succes = false;
                return response;
            }

            var clienteFound = _queryCliente.searchClientByEmail(cliente);
            if (clienteFound.Count != 0)
            {
                response.succes = false;
                response.content = "Este Email ya esta usado";
                return response;
            }

            var clientCreated = _clienteCommand.InsertClientDataBase(cliente);
            if (!clientCreated.succes)
            {
                response.succes = false;
                response.content = clientCreated.content;
            }

            return response;
        }


        public Response getClienteById(int cliente)
        {
            var response = new Response(true, "Cliente encontrado");

            var query = _queryCliente.searchClientById(cliente);

            if (query == null)
            {
                response.succes = false;
                response.content = "No se encontro el cliente con ese Id";
            }
            else
            {
                response.objects = query;
            }

            return response;
        }

        public Response getClienteByOthers(string? dni, string? nombre, string? apellido)
        {
            var response = new Response(true, "Cliente Encontrado");
            var query = _queryCliente.searchClientOthers(dni, nombre, apellido);
            if (query == null)
            {
                response.succes = false;
                response.content = "El cliente no existe";
            }
            else
            {
                response.objects = query;
            }
            return response;
        }




        private Response validatedFields(DtoGetCliente cliente)
        {
            var response = new Response(true, "Los datos del Cliente son correctos");


            if (cliente.Nombre == "" || cliente.Nombre == null)
            {
                response.content = "El campo de Nombre ingresado es nulo o se encuentra vacio";
                response.succes = false;
                return response;
            }

            if (cliente.Apellido == "" || cliente.Apellido == null)
            {
                response.content = "El campo de Apellido ingresado es nulo o se encuentra vacio";
                response.succes = false;
                return response;
            }

            try
            {
                int proof = Convert.ToInt32(cliente.DNI);
                if (cliente.DNI.ToString() == "" || cliente.DNI.ToString() == null)
                {
                    response.content = "El campo de DNI ingresado es nulo o se encuentra vacio";
                    response.succes = false;
                    return response;
                }
            }
            catch (Exception)
            {
                response.content = "Se ha ingresado un caracter no correspondiente en el DNI";
                response.succes = false;
                return response;

            }

            if (cliente.Email == "" || cliente.Email == null)
            {
                response.content = "El campo de Email ingresado es nulo o se encuentra vacio";
                response.succes = false;
                return response;
            }

            return response;
        }
    }
}
