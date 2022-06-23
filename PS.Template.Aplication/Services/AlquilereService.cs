using PS.Template.Aplication.Interfaces;
using PS.Template.Aplication.Interfaces.interface_Alquiler;
using PS.Template.Aplication.Interfaces.Interface_Estado;
using PS.Template.Aplication.Interfaces.Interface_Libro;
using PS.Template.Aplication.Message;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Models;
using System.Collections;

namespace PS.Template.Aplication.Services
{
    public class AlquilereService : IAlquilerService
    {
        private readonly IAlquilerCommands _alquilerCommands;
        private readonly IQueryAlquiler _queryAlquiler;
        private readonly IQueryLibro _queryLibro;
        private readonly IQueryCliente _queryCliente;
        public AlquilereService(IAlquilerCommands alq, IQueryEstado queryEstado, IQueryLibro queryLibro, IQueryCliente queryCliente, IQueryAlquiler queryAlquileres)
        {
            _alquilerCommands = alq;
            _queryAlquiler = queryAlquileres;
            _queryLibro = queryLibro;
            _queryCliente = queryCliente;
        }

        public Response CreateAlquiler(DtoAlquiler dtoAlquiler)
        {
            var response = new Response(true, "AlquilerRegistrado Correctamente");
            response.statuscode = 201;

            var validate = this.ValidateAlquiler(dtoAlquiler.cliente, dtoAlquiler.ISBN);
      
            if (!validate.succes)
            {
                response.succes = false;
                response.content = validate.content;
                response.statuscode = 404;
                return response;
            }

            var dateValidate = this.ValidateDates(dtoAlquiler.cliente,dtoAlquiler.ISBN);

            if (!dateValidate.succes)
            {
                response.succes = false;
                response.content = dateValidate.content;
                response.statuscode = 404;
                return response;
            }
            if (dtoAlquiler.fechaAlquiler == null || dtoAlquiler.fechaReserva == null)
            {
                if (dtoAlquiler.fechaAlquiler == null)
                {
                    response = _alquilerCommands.CreateReserva(dtoAlquiler);
                }
                else
                {
                    response = _alquilerCommands.CreateAlquiler(dtoAlquiler);
                }
            }
            else
            {
                response.succes = false;
                response.content = "Se tiene una fecha de alquiler y reserva iguales";
            }          
            return response;
        }
        public Response searchLibroByClient(int id)
        {
            var response = new Response(true,"El cliente tiene un alquiler/reserva");
            response.statuscode = 200;
            var clientExist = _queryAlquiler.listAlquiler();
            List<DtoLibroCliente> listDtoLibro = new List<DtoLibroCliente>();

            foreach (Alquileres alquileres in clientExist)
            {
                if (alquileres.ClienteId == id)
                {
                    bool repetido = true;
                    var libroExist = _queryLibro.searchLibroByISBN(alquileres.IsbnId);
                    var dtoLibroGuardado = new DtoLibroCliente();

                    if (listDtoLibro.Count == 0)
                    {
                        dtoLibroGuardado.ISBN = libroExist.ISBN;
                        dtoLibroGuardado.Titulo = libroExist.Titulo;
                        dtoLibroGuardado.Stock = libroExist.Stock;
                        dtoLibroGuardado.cantidad++;
                        listDtoLibro.Add(dtoLibroGuardado);
                    }
                    else
                    {
                        foreach (DtoLibroCliente dtolibro in listDtoLibro)
                        {
                            if (alquileres.IsbnId == dtolibro.ISBN)
                            {
                                dtolibro.cantidad++;
                                repetido = false;
                            }
                        }
                        if (repetido)
                        {
                            dtoLibroGuardado.ISBN = libroExist.ISBN;
                            dtoLibroGuardado.Titulo = libroExist.Titulo;
                            dtoLibroGuardado.Stock = libroExist.Stock;
                            dtoLibroGuardado.cantidad++;
                            listDtoLibro.Add(dtoLibroGuardado);
                        }
                    }
                }
                else
                {
                    response.succes = false;
                    response.content = "El cliente no teiene Reservas/Alquileres registrados";
                }
            }
            response.objects = listDtoLibro;
            return response;
        }
        public Response putAlquiler(DtoReserva dtoReserva) {

            var response = new Response(true,"Reserva Actualizada");
            response.statuscode = 200;
            int estadoAux = 2;
            var validate = this.ValidateDatesPut(dtoReserva.cliente,dtoReserva.isbn);
            if (!validate.succes)
            {
                response.succes = validate.succes;
                response.content = validate.content;
                return response;
            }
            var alquilerExist = _queryAlquiler.getAlquileresByClientIsbn(dtoReserva.cliente, dtoReserva.isbn,estadoAux);
            
            var libro = _queryLibro.searchLibroByISBN(dtoReserva.isbn);
            if (libro.Stock>=0)
            {
                if (alquilerExist != null)
                {
                    if (alquilerExist.EstadoDeAlquileresId == 2)
                    {
                        _alquilerCommands.putAlquiler(alquilerExist);
                    }
                    else
                    {
                        response.succes = false;
                        response.content = "El cliente ya tiene alquilado ese libro";
                        response.statuscode = 404;
                    }
                }
            }
            return response;
        }
        public Response GetAlquilerByEstado(int estado) {
            var response = new Response(true,"Lista de Libros Reservados/Alquilados");

            var estadoAlquiler = _queryAlquiler.listAlquiler();
            
            ArrayList array = new ArrayList();
            foreach (Alquileres al in estadoAlquiler)
            {
                var libroExist = _queryLibro.searchLibroByISBN(al.IsbnId);
                if (al.EstadoDeAlquileresId == estado)
                {                
                    array.Add(new
                    {
                        clienteid = al.ClienteId,
                        ISBN = libroExist.ISBN,
                        Titulo = libroExist.Titulo,
                        Autor = libroExist.Autor,
                        Editorial = libroExist.Editorial,
                        Edicion = libroExist.Edicion,
                        Stock = libroExist.Stock,
                        Imagen = libroExist.Imagen,
                        FechaAlquiler = al.FechaAlquiler,
                        FechaReserva = al.FechaReserva,
                        FechaDevolucion = al.FechaDevolucion
                    });
                    response.arrList = array;
                }
                if (estado < 1 || estado > 3)
                {
                    array.Add(new
                    {
                        clienteid = al.ClienteId,
                        ISBN = libroExist.ISBN,
                        Titulo = libroExist.Titulo,
                        Autor = libroExist.Autor,
                        Editorial = libroExist.Editorial,
                        Edicion = libroExist.Edicion,
                        Stock = libroExist.Stock,
                        Imagen = libroExist.Imagen,
                        FechaAlquiler = al.FechaAlquiler,
                        FechaReserva = al.FechaReserva,
                        FechaDevolucion = al.FechaDevolucion
                    });
                    response.arrList = array;
                }        
            }          
            return response;
        }






        private Response ValidateAlquiler(int clienteId, string isbn)
        {
            var response = new Response(true, "Datos validados");
            try
            {
                if (clienteId.Equals(null))
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

        private Response ValidateDates(int clienteId, string isbn)
        {
            MessageAlquiler messageAlquiler = new MessageAlquiler();

            var response = new Response(true, "Datos Existentes");

            var clientExist = _queryCliente.searchClientById(clienteId);

            if (clientExist == null)
            {
                response.succes = false;
                response.content = "Id del cliente no encontrado";
                return response;
            }

            var libroExist = _queryLibro.searchLibroByISBN(isbn);

            if (libroExist == null)
            {
                response.succes = false;
                response.content = "ISBN del libro no encontrado";
                return response;
            }

            if (libroExist.Stock == null || libroExist.Stock <= 0)
            {
                response.succes = false;
                response.content = "Libro encontrado pero sin Stock";
                return response;
            }
            return response;
        }
        private Response ValidateDatesPut(int clienteId, string isbn)
        {
            MessageAlquiler messageAlquiler = new MessageAlquiler();

            var response = new Response(true, "Datos Existentes");

            var clientExist = _queryCliente.searchClientById(clienteId);

            if (clientExist == null)
            {
                response.succes = false;
                response.content = "Id del cliente no encontrado";
                return response;
            }

            var libroExist = _queryLibro.searchLibroByISBN(isbn);

            if (libroExist == null)
            {
                response.succes = false;
                response.content = "ISBN del libro no encontrado";
                return response;
            }

            return response;
        }
    }
}
