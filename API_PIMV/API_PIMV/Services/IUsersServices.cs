using API_PIMV.Models;
using API_PIMV.Dtos;
namespace API_PIMV.Services
{
    public interface IUsersServices
    {
		Task<List<UsersGetResponse>> GetAllUsers();
		Task<UsersGetResponse?> GetUsers(int id);
		Task<bool> RegisterUser(UserRegister user);
        Task<bool> LoginUser(Users user);
        Task<bool> AddComent(int eventId, int userId);
        Task<bool> RegisterToEvent(int eventId, int userId);
    }
}
