using API_PIMV.Dtos;
using API_PIMV.Models;

namespace API_PIMV.Services
{
    public interface ISiteService
    {
        Task<bool> AddComent(int eventId, int userId, string comment);
        Task<List<Comments>> ShowComments(int eventId);
        Task<bool> RegisterToEvent(int eventId, int userId);
        Task<List<UsersGetResponse>> UsersReginterInTheEvent(int eventId);
    }
}

