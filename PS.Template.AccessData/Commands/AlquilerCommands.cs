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
                var reserva = new Alquileres()
                {
                    ClienteId = dtoAlquiler.ClienteId,
                    IsbnId = dtoAlquiler.IsbnId,
                    EstadoDeAlquileresId = 2, 
                    FechaReserva = dtoAlquiler.fechaReserva,
                    FechaAlquiler = null,
                    FechaDevolucion = null
                };

                _context.alquileres.Add(reserva);
                _context.SaveChanges();

                return new Response(true, "Reserva realizada");
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
                var lib = _context.libros.Find(dtoAlquiler.IsbnId);
                lib.Stock--;
                var alquler = new Alquileres()
                {
                    ClienteId = dtoAlquiler.ClienteId,
                    IsbnId = dtoAlquiler.IsbnId,
                    EstadoDeAlquileresId = 1,
                    FechaReserva = null,
                    FechaAlquiler = dtoAlquiler.fechaAlquiler,
                    FechaDevolucion = dtoAlquiler.fechaAlquiler.Value.AddDays(7)
                };

                _context.alquileres.Add(alquler);
                _context.SaveChanges();

                return new Response(true, "Alquiler realizada");
            }
            catch (Exception)
            {
                return new Response(true, "Internal Server Error");
            }
        }
    }
}
