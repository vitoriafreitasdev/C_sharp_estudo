using API_PIMV.Dtos;
using API_PIMV.Models;

namespace API_PIMV.Services
{
    public interface IEventsServices
    {
		Task<List<EventsResponse>> GetEvents();
		Task<EventsResponse?> GetEvent(int eventId);
		Task<List<GetUserEventResponse>> GetUserEvents(int userId);
		Task<bool> RegisterToEvent(int eventId, int userId);
		Task<bool> EditEvent(int eventId, int userId);
		Task<bool> DeleteEvent(int eventId, int userId);
		Task<bool> AddComent(int eventId, int userId);
    }
}
