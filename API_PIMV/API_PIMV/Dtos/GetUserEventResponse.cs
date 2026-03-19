using API_PIMV.Models;

namespace API_PIMV.Dtos
{
    public class GetUserEventResponse
    {
        public int Id { get; set; }

        public int Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Key { get; set; }

        public int User_Id { get; set; }
    }
}
