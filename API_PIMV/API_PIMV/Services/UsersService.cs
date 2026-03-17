using API_PIMV.Dtos;
using API_PIMV.Models;

namespace API_PIMV.Services
{
    public class UsersService : IUsersServices
    {
        public Task<List<UsersGetResponse>> GetAllCharacters()
        {
            throw new NotImplementedException();
        }
        public Task<UsersGetResponse?> GetUsers(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUser(UserRegister user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoginUser(Users user)
        {
            throw new NotImplementedException();
        }
    }
}

