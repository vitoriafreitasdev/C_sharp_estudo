using API_PIMV.Dtos;
using API_PIMV.Models;

namespace API_PIMV.Services
{
    public interface IEventsServices
    {
		Task<List<EventsResponse>> GetEvents();
		Task<EventsResponse?> GetEventById(int eventId);
		Task<List<GetUserEventResponse?>> GetEventsRegisteredByUser(int userId);
		Task<Events> AddEvent(Events eventObj);
		Task<bool> EditEvent(int eventId, int userId);
		Task<bool> DeleteEvent(int eventId, int userId);
		Task<CertificateResponse> Certificate(int eventId, int userId);
		
    }
}
