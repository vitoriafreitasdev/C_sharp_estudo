using API_PIMV.Models;

namespace API_PIMV.Dtos
{
    public class EventsResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int User_Id { get; set; }
    }
}
