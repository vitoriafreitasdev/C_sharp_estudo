using API_PIMV.Dtos;
using API_PIMV.Models;

namespace API_PIMV.Services
{
    public interface ISiteService
    {
        Task<bool> AddComent(AddComentRequest comment);
        Task<List<Comments>> ShowComments(int eventId);
        Task<bool> RegisterToEvent(DeleteRegistEventRequest request);
        Task<List<UserRegisteredEvent>> UsersReginterInTheEvent(int eventId);
    }
}

