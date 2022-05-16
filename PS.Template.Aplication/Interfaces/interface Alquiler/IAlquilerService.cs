using PS.Template.Aplication.Utils;
using PS.Template.Domain.DTO;

namespace PS.Template.Aplication.Interfaces.interface_Alquiler
{
    public interface IAlquilerService
    {
        public Response CreateAlquiler(DtoAlquiler dtoAlquiler);
    }
}
