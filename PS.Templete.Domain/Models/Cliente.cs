using System.Text.Json.Serialization;


namespace PS.Template.Domain.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public virtual ICollection<Alquileres>? Alquiler_C { get; set; } = null;
    }
}
