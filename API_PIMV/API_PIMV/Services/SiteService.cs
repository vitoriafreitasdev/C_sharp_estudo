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

            var user = await context.Users.Where(c => c.Id == userId).FirstOrDefaultAsync();

            if (user == null) throw new Exception("Usuário não registrado.");

            var events = await context.Events.Where(c => c.Id == eventId).FirstOrDefaultAsync();

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

        public Task<List<Comments>> ShowComments(int eventId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> RegisterToEvent(int eventId, int userId)
        {
            throw new NotImplementedException();
        }

   
    }
}
