using Microsoft.EntityFrameworkCore;
using API_PIMV.Data;
using API_PIMV.Models;
using API_PIMV.Dtos;
using static BCrypt.Net.BCrypt;

namespace API_PIMV.Services
{
    public class UsersService(AppDbContext context) : IUsersServices
    {

        public async Task<List<UsersGetResponse>> GetAllUsers()
        {

            try
            {
                var users = await context.Users.Select(c => new UsersGetResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Age = c.Age,
                    Email = c.Email
                }).ToListAsync();

                return users;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return [];
            }
        }
        public async Task<UsersGetResponse?> GetUsers(int id)
        {

            try
            {
                var user = await context.Users
                .Where(c => c.Id == id)
                .Select(c => new UsersGetResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Age = c.Age,
                    Email = c.Email
                }).FirstOrDefaultAsync();

                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<UserRegisterResponse> RegisterUser(UsersRegisterRequest user)
        {
                var userExist = await context.Users
                    .Where(c => c.Email == user.Email)
                    .FirstOrDefaultAsync();

                    
                if(userExist != null) throw new Exception("E-mail já existente, coloque outro");

                if(user.Age < 18) throw new Exception("Usuário menor de idade");

                var userPassword = user.Password;
                var hashPassword = HashPassword(userPassword, 12);
                var NewUser = new Users
                {
                    Name = user.Name,
                    Age = user.Age,
                    Email = user.Email,
                    Password = hashPassword

                };

                context.Users.Add(NewUser);
                await context.SaveChangesAsync();

                return new UserRegisterResponse
                {
                    Id = NewUser.Id,
                    Name = NewUser.Name,
                    Age = NewUser.Age,
                    Email = NewUser.Email,
                    Password = hashPassword
                };

        }

        public Task<UserLoginResponse> LoginUser(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddComent(int eventId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterToEvent(int eventId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}

