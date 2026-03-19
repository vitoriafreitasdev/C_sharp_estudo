namespace API_PIMV.Models
{
    public class Events
    {

        public int Id {get; set; } 

        public string Title { get; set; }

        public string Description { get; set; }
        
        public DateTime Date { get; set; }

        public string Key { get; set; }

        public int User_Id { get; set; }
    }
}
