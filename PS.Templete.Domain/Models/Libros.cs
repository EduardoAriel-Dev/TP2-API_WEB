namespace PS.Template.Domain.Models
{
    public class Libros
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Edicion { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        public ICollection<Alquileres>? alquileres_L { get; set; }
    }
}
