using PS.Template.Aplication.Utils;
using PS.Template.Domain.Models;

namespace PS.Template.Aplication.Message
{
    public class MessageAlquiler
    {
        public Cliente? cliente { get; set; }
        public Libros? libros { get; set; }
        public EstadoDeAlquileres? estadoDeAlquileres { get; set; }
        public Alquileres? alquileres { get; set; }
        public Response? repuesta { get; set; }
        public List<Alquileres>? listAlquiler { get; set; }

    }
}
