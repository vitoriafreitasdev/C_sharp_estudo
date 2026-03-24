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

            var users = await context.Users.Select(c => new UsersGetResponse
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                Email = c.Email
            }).ToListAsync();

            if (users == null || users.Count == 0) throw new Exception("Usuários não encontrados");

            return users;

            
        }
        public async Task<UsersGetResponse?> GetUsers(int id)
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

            if (user == null) throw new Exception("Usuário não encontrado.");

            return user;
            
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
                    Email = NewUser.Email
                };

        }

        public async Task<UserLoginResponse> LoginUser(UserLoginRequest user)
        {
            var userFind = await context.Users
                .Where(c => c.Email == user.Email)
                .FirstOrDefaultAsync();

            if(userFind == null) throw new Exception("E-mail inválido.");

            var passwordIsCorrect = Verify(user.Password, userFind.Password);

            if (passwordIsCorrect == false) throw new Exception("Senha inválida.");

            UserLoginResponse requestReturn = new UserLoginResponse()
            {
                Id = userFind.Id,
                Name = userFind.Name,
                Email = userFind.Email
            }; 

            return requestReturn;

        }

       
    }
}

