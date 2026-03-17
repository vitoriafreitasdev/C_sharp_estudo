using API_PIMV.Models;

namespace API_PIMV.Dtos
{
    public class EventsResponse
    {
        public int EventId { get; set; }

        public int Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public List<Users> RegisteredUsers { get; set; }

        public List<string> Comments { get; set; }

        public int User_Id { get; set; }
    }
}
