namespace API_PIMV.Services
{
    public interface ISiteService
    {
        Task<bool> AddComent(int eventId, int userId);
        Task<bool> RegisterToEvent(int eventId, int userId);
    }
}

/* criar o  SiteService */