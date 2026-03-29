using API_PIMV.Classes;
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

            var userEvents = events
            .Where(e => e.User_Id == userId)
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
        public async Task<Events> AddEvent(AddEventRequest eventObj)
        {
            var user = await context.Users.FindAsync(eventObj.User_Id);

            var eventFind = await context.Events.Where(c => c.Key == eventObj.Key).FirstOrDefaultAsync();

            if(eventFind != null) throw new Exception("Essa chave já existe.");

            if (user == null) throw new Exception("Usuário não encontrado.");

            var newEvent = new Events()
            {
                Title = eventObj.Title,
                Description = eventObj.Description,
                Date = eventObj.Date,
                User_Id = eventObj.User_Id,
                Key = eventObj.Key
            };

            context.Events.Add(newEvent);
            await context.SaveChangesAsync();

            return new Events()
            {
                Id = newEvent.Id,
                Title = newEvent.Title,
                Description = newEvent.Description,
                Date = newEvent.Date,
                User_Id = newEvent.User_Id,
                Key = newEvent.Key
            };
        }
        public async Task<Events> EditEvent(Events events)
        {
            var eventFind = await context.Events.FindAsync(events.Id);

            if(eventFind == null) throw new Exception("Evento não encontrado.");

            if(eventFind.User_Id != events.User_Id) throw new Exception("Esse evento pode apenas ser editado pelo usuário que o criou.");

            
            eventFind.Title = events.Title;
            eventFind.Description = events.Description;
            eventFind.Date = events.Date;
            eventFind.Key = events.Key;

            await context.SaveChangesAsync();

            return eventFind;

        }
        public async Task<bool> DeleteEvent(DeleteRegistEventRequest request)
        {
            var eventFind = await context.Events.FindAsync(request.eventId);
            //Removendo da tabela de usuários incritos também
            await context.RegisteredUsersInEvents
            .Where(c => c.eventId == request.eventId)
            .ExecuteDeleteAsync();

            if (eventFind == null) throw new Exception("Evento não encontrado.");

            if (eventFind.User_Id != request.userId) throw new Exception("Esse evento pode apenas ser deletado pelo usuário que o criou.");

            context.Events.Remove(eventFind);

            await context.SaveChangesAsync();

            return true;
        }
        
        public async Task<Certificate> Certificate(CertificateRequest certificateBody)
        {
            var user = await context.Users.FindAsync(certificateBody.userId);

            if (user == null) throw new Exception("Usuário não encontrado.");

            var eventFind = await context.Events.Where(c => c.Key == certificateBody.key).FirstAsync();

            if (eventFind == null) throw new Exception("Evento não encontrado.");

            var certificate = new Certificate()
            {
                EventTitle = eventFind.Title,
                UserName = user.Name,
                Description = eventFind.Description,
                Date = eventFind.Date
            };

            return certificate;
        }
        
    }
}
