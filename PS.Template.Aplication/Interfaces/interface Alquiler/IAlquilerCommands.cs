using PS.Template.Aplication.Message;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.DTO;

namespace PS.Template.Aplication.Interfaces.interface_Alquiler
{
    public interface IAlquilerCommands
    {
        public Response CreateReserva(DtoAlquiler dtoAlquiler);
        public Response CreateAlquiler(DtoAlquiler dtoAlquiler);

    }
}