using Microsoft.EntityFrameworkCore;
using API_PIMV.Data;
using API_PIMV.Models;
using API_PIMV.Dtos;
namespace API_PIMV.Services
{
    public class SiteService(AppDbContext context) : ISiteService
    {
        public async Task<Comments> AddComent(AddComentRequest comment)
        {

            var user = await context.Users.FindAsync(comment.userId);

            if (user == null) throw new Exception("Usuário não registrado.");

            var events = await context.Events.FindAsync(comment.eventId);

            if (events == null) throw new Exception("Evento não registrado");

            Comments newComment = new Comments()
            {
                Commentary = comment.comment,
                UserId = comment.userId,
                EventId = comment.eventId,
            };

            context.Comments.Add(newComment);

            await context.SaveChangesAsync();

            return newComment;

        }

        public async Task<List<CommentsRes>> ShowComments(int eventId)
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

            List<CommentsRes> response = new List<CommentsRes>();
        
            foreach (var comment in comments)
            {
                var user = await context.Users.FindAsync(comment.UserId);
                if (user != null)
                {
                    response.Add(new CommentsRes
                    {
                        Id = comment.Id,
                        Commentary = comment.Commentary,
                        UserName = user.Name
                    });
                }
            }

            if (response == null || response.Count() == 0)
            {
                throw new Exception("Evento sem comentários.");
            }

            return response;
        }
        public async Task<bool> RegisterToEvent(DeleteRegistEventRequest request)
        {
            var user = await context.Users.FindAsync(request.userId);

            if (user == null) throw new Exception("Usuário não registrado.");

            var events = await context.Events.FindAsync(request.eventId);

            if (events == null) throw new Exception("Evento não registrado");

            var registers = await context.RegisteredUsersInEvents
            .Where(c => c.userId == request.userId && c.eventId == request.eventId)
            .ToListAsync();

            var alreadyRegisterde = registers.Exists(x => x.eventId == request.eventId && x.userId == request.userId);

            if (alreadyRegisterde) throw new Exception("Já registrado.");

            RegisteredUsersInEvents register = new RegisteredUsersInEvents()
            {
                userId = request.userId,
                eventId = request.eventId,
            };

            context.RegisteredUsersInEvents.Add(register);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<List<UserRegisteredEvent>> UsersReginterInTheEvent(int eventId)
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
            .Select(c => new UserRegisteredEvent
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
