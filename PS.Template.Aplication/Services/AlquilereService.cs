using PS.Template.Aplication.Interfaces;
using PS.Template.Aplication.Interfaces.interface_Alquiler;
using PS.Template.Aplication.Interfaces.Interface_Estado;
using PS.Template.Aplication.Interfaces.Interface_Libro;
using PS.Template.Aplication.Message;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.DTO;

namespace PS.Template.Aplication.Services
{
    public class AlquilereService : IAlquilerService
    {
        private readonly IAlquilerCommands _alquilerCommands;
        private readonly IQueryAlquiler _queryAlquiler;
        private readonly IQueryEstado _queryEstado;
        private readonly IQueryLibro _queryLibro;
        private readonly IQueryCliente _queryCliente;
        public AlquilereService(IAlquilerCommands alq, IQueryAlquiler query, IQueryEstado queryEstado, IQueryLibro queryLibro, IQueryCliente queryCliente)
        {
            _alquilerCommands = alq;
            _queryAlquiler = query;
            _queryEstado = queryEstado;
            _queryLibro = queryLibro;
            _queryCliente = queryCliente;
        }

        public Response CreateAlquiler(DtoAlquiler dtoAlquiler)
        {
            var response = new Response(true, "AlquilerRegistrado Correctamente");

            var validate = this.ValidateAlquiler(dtoAlquiler.ClienteId, dtoAlquiler.IsbnId);

            if (!validate.succes)
            {
                response.succes = false;
                response.content = validate.content;
            }

            var dateValidate = this.ValidateDates(dtoAlquiler);

            if (!dateValidate.succes)
            {
                response.succes = false;
                response.content = dateValidate.content;
            }

            if (dtoAlquiler.fechaAlquiler == null)
            {
                return (response = _alquilerCommands.CreateReserva(dtoAlquiler));
            }
            else
            {
                return (response = _alquilerCommands.CreateAlquiler(dtoAlquiler));
            }
            return response;
        }

        private Response ValidateAlquiler(int clienteId, string isbn)
        {
            var response = new Response(true, "Datos validados");
            try
            {
                if (clienteId == null)
                {
                    response.succes = false;
                    response.content = "El cliente no puede ser null";
                    return response;
                }
            }
            catch (Exception)
            {
                response.succes = false;
                response.content = "El Id es erroneo";
                return response;
            }
            try
            {
                if (isbn == null || isbn.Length > 45)
                {
                    response.succes = false;
                    response.content = "El isbn es no puede ser null o mayor a 45";
                    return response;
                }
            }
            catch (Exception)
            {
                response.succes = false;
                response.content = "isbn es erroneo";
                return response;
            }
            return response;
        }
        private Response ValidateDates(DtoAlquiler dtoAlquiler)
        {

            MessageAlquiler messageAlquiler = new MessageAlquiler();

            var response = new Response(true, "Datos Existentes");

            var clientExist = _queryCliente.searchClientById(dtoAlquiler.ClienteId);

            if (clientExist == null)
            {
                response.succes = false;
                response.content = "Id del cliente no encontrado";
                
            }

            var libroExist = _queryLibro.searchLibroByISBN(dtoAlquiler.IsbnId);

            if (libroExist == null)
            {
                response.succes = false;
                response.content = "ISBN del libro no encontrado";
                
            }

            if (libroExist.Stock == null || libroExist.Stock <= 0)
            {
                response.succes = false;
                response.content = "Libro encontrado pero sin Stock";
                
            }
            return response;
        }
    }
}
