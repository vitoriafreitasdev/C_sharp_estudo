using API_PIMV.Models;
using API_PIMV.Dtos;
namespace API_PIMV.Services
{
    public interface IUsersServices
    {
		Task<List<UsersGetResponse>> GetAllCharacters();
		Task<UsersGetResponse?> GetUsers(int id);
		Task<bool> RegisterUser(UserRegister user);
        Task<bool> LoginUser(Users user);
    }
}
