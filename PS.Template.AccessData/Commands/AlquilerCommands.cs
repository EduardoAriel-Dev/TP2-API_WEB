using PS.Template.AccessData.DbContexts;
using PS.Template.Aplication.Interfaces.interface_Alquiler;
using PS.Template.Aplication.Message;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Models;

namespace PS.Template.AccessData.Commands
{
    public class AlquilerCommands : IAlquilerCommands
    {
        private readonly MyDbContext _context;

        public AlquilerCommands(MyDbContext cont)
        {
            _context = cont;
        }

        public Response CreateReserva(DtoAlquiler dtoAlquiler)
        {
            try
            {
                var response = new Response(true, "Reserva realizada");
                var lib = _context.libros.Find(dtoAlquiler.ISBN);
                lib.Stock--;
                var reserva = new Alquileres()
                {
                    ClienteId = dtoAlquiler.cliente,
                    IsbnId = dtoAlquiler.ISBN,
                    EstadoDeAlquileresId = 2, 
                    FechaReserva = dtoAlquiler.fechaReserva,
                    FechaAlquiler = null,
                    FechaDevolucion = null
                };

                _context.alquileres.Add(reserva);
                _context.SaveChanges();
                response.objects = reserva;

                return response;
            }
            catch (Exception)
            {
                return new Response(true, "Internal Server Error");
            }
        }
        public Response CreateAlquiler(DtoAlquiler dtoAlquiler)
        {
            try
            {
                var response = new Response(true,"Alquiler realizado");
                var lib = _context.libros.Find(dtoAlquiler.ISBN);
                lib.Stock--;
                var alquler = new Alquileres()
                {
                    ClienteId = dtoAlquiler.cliente,
                    IsbnId = dtoAlquiler.ISBN,
                    EstadoDeAlquileresId = 1,
                    FechaReserva = null,
                    FechaAlquiler = dtoAlquiler.fechaAlquiler,
                    FechaDevolucion = dtoAlquiler.fechaAlquiler.Value.AddDays(7)
                };

                _context.alquileres.Add(alquler);
                _context.SaveChanges();
                response.objects = alquler;

                return response;
            }
            catch (Exception)
            {
                return new Response(true, "Internal Server Error");
            }
        }

        public Response putAlquiler(Alquileres alquileres) {
            try
            {
                var response = new Response(true,"Reserva Actualizada");
                alquileres.FechaReserva = null;
                alquileres.FechaAlquiler = DateTime.Now;
                alquileres.FechaDevolucion = DateTime.Now.AddDays(7);
                alquileres.EstadoDeAlquileresId = 1;

                _context.Update<Alquileres>(alquileres);
                _context.SaveChanges();

                return response;
            }
            catch (Exception)
            {
                return new Response(true, "Internal Server Error");
            }

        }
    }
}
