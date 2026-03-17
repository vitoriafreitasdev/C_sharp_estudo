using API_PIMV.Dtos;
using API_PIMV.Models;

namespace API_PIMV.Services
{
    public class EventsServices : IEventsServices
    {
        public Task<EventsResponse?> GetEvent(int eventId)
        {
            throw new NotImplementedException();
        }
        public Task<List<EventsResponse>> GetEvents()
        {
            throw new NotImplementedException();
        }
        public Task<List<GetUserEventResponse>> GetUserEvents(int userId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteEvent(int eventId, int userId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditEvent(int eventId, int userId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> RegisterToEvent(int eventId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddComent(int eventId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
