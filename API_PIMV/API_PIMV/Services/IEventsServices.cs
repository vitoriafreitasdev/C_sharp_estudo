using API_PIMV.Classes;
using API_PIMV.Dtos;
using API_PIMV.Models;

namespace API_PIMV.Services
{
    public interface IEventsServices
    {
		Task<List<EventsResponse>> GetEvents();
		Task<EventsResponse?> GetEventById(int eventId);
		Task<List<GetUserEventResponse?>> GetEventsRegisteredByUser(int userId);
		Task<Events> AddEvent(AddEventRequest eventObj);
		Task<Events> EditEvent(Events events);
		Task<bool> DeleteEvent(DeleteRegistEventRequest request);
		Task<Certificate> Certificate(CertificateRequest certificateBody);
		
    }
}
