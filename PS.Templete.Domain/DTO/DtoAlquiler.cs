namespace PS.Template.Domain.DTO
{
    public class DtoAlquiler
    {
        public int cliente { get; set; }
        public string ISBN { get; set; }
        public DateTime? fechaAlquiler { get; set; }
        public DateTime? fechaReserva { get; set; }
    }
}
