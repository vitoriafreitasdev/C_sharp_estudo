namespace API_PIMV.Dtos
{
    public class AddComentRequest
    {
        public int eventId { get; set; }
        public int userId { get; set; }
        public string comment { get; set; }
    }
}
