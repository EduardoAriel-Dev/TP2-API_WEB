namespace PS.Template.Domain.DTO
{
    public class DtoAlquiler
    {
        public int ClienteId { get; set; }
        public string IsbnId { get; set; }
        public DateTime? fechaAlquiler { get; set; }
        public DateTime? fechaReserva { get; set; }
    }
}
