namespace API_PIMV.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Commentary { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
