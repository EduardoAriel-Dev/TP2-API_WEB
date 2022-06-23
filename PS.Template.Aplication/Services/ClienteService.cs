using PS.Template.Aplication.Interfaces;
using PS.Template.Aplication.Interfaces.interface_Alquiler;
using PS.Template.Aplication.Interfaces.Interface_Libro;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.DTO;
using System.Collections;


namespace PS.Template.Aplication.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteCommand _clienteCommand;
        private readonly IQueryCliente _queryCliente;
        private readonly IQueryAlquiler _queryAlquiler;
        private readonly IQueryLibro _queryLibro;
        public ClienteService(IClienteCommand com, IQueryCliente query, IQueryAlquiler queryAlquiler, IQueryLibro queryLibro)
        {
            _clienteCommand = com;
            _queryCliente = query;
            _queryAlquiler = queryAlquiler;
            _queryLibro = queryLibro;
        }
        public Response createClient(DtoGetCliente cliente)
        {
            var response = new Response(true, "El cliente se ha Creado Correctamente");
            response.statuscode = 201;
            var fieldsValid = this.validatedFields(cliente);
            if (!fieldsValid.succes)
            {
                response.content = fieldsValid.content;
                response.succes = false;
                response.statuscode = 404;
                return response;
            }

            var clienteFound = _queryCliente.searchClientByEmail(cliente);
            
            if (clienteFound != null)
            { 
                response.succes = false;
                response.content = "Email ya existentes";
                response.statuscode = 404;
                return response;
            }
            var dniFound = _queryCliente.SearchClientByDNI(cliente.DNI);
            if (dniFound != null)
            {
                response.succes = false;
                response.content = "DNI ya existente";
                response.statuscode = 404;
                return response;
            }

            var clientCreated = _clienteCommand.InsertClientDataBase(cliente);
            response.objects = clientCreated.objects;
            if (!clientCreated.succes)
            {
                response.succes = false;
                response.content = clientCreated.content;
                response.statuscode = 404; 
            }

            return response;
        }
        public Response getClienteById(int cliente)
        {
            var response = new Response(true, "Cliente encontrado");
            response.statuscode = 200;
            var query = _queryCliente.searchClientById(cliente);

            if (query == null)
            {
                response.succes = false;
                response.content = "No se encontro el cliente con ese Id";
                response.statuscode = 400;
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
            response.statuscode = 200;
            var query = _queryCliente.searchClientOthers(dni, nombre, apellido);
            if (query == null)
            {
                response.succes = false;
                response.content = "El cliente no existe";
                response.statuscode = 400;
            }
            else
            {
                response.objects = query;
            }
            return response;
        }
        public Response GetAlquilerByEstado(int cliente, int estado) {
            var response = new Response(true, "Lista");
            response.statuscode = 200;
            ArrayList array = new ArrayList();
            var queryClient = _queryCliente.searchClientById(cliente);
            if (queryClient == null)
            {
                response.succes = false;
                response.content = "El cliente no existe";
                response.statuscode = 400;
            }
            var queryAlquiler = _queryAlquiler.ListAlquilerByEstadoCliente(estado,cliente);
            if (queryAlquiler == null)
            {
                response.succes = false;
                response.content = "El cliente no tiene una reserva/alquiler";
                response.statuscode = 400;
            }
            foreach (var al in queryAlquiler)
            {
                var queryLibro = _queryLibro.searchLibroByISBN(al.IsbnId);
                array.Add(queryLibro);
            }
            response.arrList = array;

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
                if (cliente.DNI.ToString() == "" || cliente.DNI.ToString() == null || cliente.DNI.Length < 8 || cliente.DNI.Length > 9)
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
