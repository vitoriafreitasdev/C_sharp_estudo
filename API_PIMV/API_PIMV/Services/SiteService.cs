using Microsoft.EntityFrameworkCore;
using API_PIMV.Data;
using API_PIMV.Models;
using API_PIMV.Dtos;

namespace API_PIMV.Services
{
    public class SiteService(AppDbContext context) : ISiteService
    {
        public async Task<bool> AddComent(int eventId, int userId, string comment)
        {

            var user = await context.Users.FindAsync(userId);

            if (user == null) throw new Exception("Usuário não registrado.");

            var events = await context.Events.FindAsync(eventId);

            if (events == null) throw new Exception("Evento não registrado");

            Comments newComment = new Comments()
            {
                Commentary = comment,
                UserId = userId,
                EventId = eventId,
            };

            context.Comments.Add(newComment);

            await context.SaveChangesAsync();

            return true;

        }

        public async Task<List<Comments>> ShowComments(int eventId)
        {
            var comments = await context.Comments
            .Where(c => c.EventId == eventId)
            .Select(c => new Comments
            {   
                Id = c.Id,
                Commentary = c.Commentary,
                UserId = c.UserId,
                EventId = c.EventId
            })
            .ToListAsync();

            if(comments == null || comments.Count() == 0)
            {
                throw new Exception("Evento sem comentários.");
            }

            return comments;
        }
        public async Task<bool> RegisterToEvent(int eventId, int userId)
        {
            var user = await context.Users.FindAsync(userId);

            if (user == null) throw new Exception("Usuário não registrado.");

            var events = await context.Events.FindAsync(eventId);

            if (events == null) throw new Exception("Evento não registrado");

            RegisteredUsersInEvents register = new RegisteredUsersInEvents()
            {
                userId = userId,
                eventId = eventId,
            };

            context.RegisteredUsersInEvents.Add(register);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<List<UsersGetResponse>> UsersReginterInTheEvent(int eventId)
        {
            var events = await context.Events.FindAsync(eventId);

            if (events == null) throw new Exception("Evento não registrado");
    
            var registeredUsersInEvent = await context.RegisteredUsersInEvents
            .Where(c => c.eventId == eventId)
            .Select(c => c.userId)
            .ToListAsync();

            /* pegar os usuarios que estao dentro de  registeredUsersInEvent */

            var requestReturn = await context.Users
            .Where(c => registeredUsersInEvent.Contains(c.Id))
            .Select(c => new UsersGetResponse
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                Email = c.Email
            }).ToListAsync();


            if (requestReturn.Count() == 0 || requestReturn == null)
            {
                throw new Exception("Esse evento não tem ninguém registrado nele.");
            }

            return requestReturn;
        }
    }
}
