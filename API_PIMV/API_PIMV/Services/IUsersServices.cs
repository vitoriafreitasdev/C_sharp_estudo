using API_PIMV.Models;
using API_PIMV.Dtos;
namespace API_PIMV.Services
{
    public interface IUsersServices
    {
		Task<List<UsersGetResponse>> GetAllUsers();
		Task<UsersGetResponse?> GetUsers(int id);
		Task<UserRegisterResponse> RegisterUser(UsersRegisterRequest user);
        Task<UserLoginResponse> LoginUser(UserLoginRequest user);
        
    }
}

