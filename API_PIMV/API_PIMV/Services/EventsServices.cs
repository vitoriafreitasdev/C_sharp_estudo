using API_PIMV.Data;
using API_PIMV.Dtos;
using API_PIMV.Models;
using Microsoft.EntityFrameworkCore;

namespace API_PIMV.Services
{
    public class EventsServices(AppDbContext context) : IEventsServices
    {
        public async Task<List<EventsResponse>> GetEvents()
        {
            var events = await context.Events.Select(c => new EventsResponse
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Date = c.Date,
                User_Id = c.User_Id
            })
            .ToListAsync();

            if (events == null || events.Count == 0) throw new Exception("Eventos não encontrados.");

            return events;
        }
        public async Task<EventsResponse?> GetEventById(int eventId)
        {
            var eventFind = await context.Events
            .Where(c => c.Id == eventId)
            .Select(c => new EventsResponse
            {
                Id = c.Id,
                Title = c.Title,
                Date = c.Date,
                Description = c.Description,
                User_Id = c.User_Id
            })
            .FirstOrDefaultAsync();

            if (eventFind == null) throw new Exception("Evento não encontrado.");

            return eventFind;

        }
        public async Task<List<GetUserEventResponse?>> GetEventsRegisteredByUser(int userId)
        {
            var events = await context.Events.Select(c => new Events
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Date = c.Date,
                User_Id = c.User_Id, 
                Key = c.Key
            })
            .ToListAsync();

            var userEvents = events.Where(e => e.User_Id == userId)
            .Select(e => new GetUserEventResponse()
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Date = e.Date,
                User_Id = e.User_Id,
                Key = e.Key
            })
            .ToList();

            if (userEvents == null || userEvents.Count() == 0) throw new Exception("Evento não encontrado.");

            return userEvents;
        }
        public Task<Events> AddEvent(Events eventObj)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditEvent(int eventId, int userId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteEvent(int eventId, int userId)
        {
            throw new NotImplementedException();
        }
        
        public Task<CertificateResponse> Certificate(int eventId, int userId)
        {
            /* Criar um modelo para o certificado */
            throw new NotImplementedException();
        }
        
    }
}
