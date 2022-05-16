namespace PS.Template.Domain.Models
{
    public class EstadoDeAlquileres
    {
        public int EstadoId { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Alquileres>? Alquileres_EA { get; set; }
    }
}
