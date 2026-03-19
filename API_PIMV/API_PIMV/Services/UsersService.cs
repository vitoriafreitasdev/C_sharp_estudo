using Microsoft.EntityFrameworkCore;
using API_PIMV.Data;
using API_PIMV.Models;
using API_PIMV.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public Task<bool> RegisterUser(UserRegister user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoginUser(Users user)
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

