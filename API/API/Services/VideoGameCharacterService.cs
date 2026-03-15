
// services
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using API.Dtos;

namespace API.Services
{
    public class VideoGameCharacterService(AppDbContext context) : IVideoGamesCharacterService
    {

        public Task<CharacterResponse> AddCharacterByIdAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CharacterResponse>> GetAllCharactersAsync()
            => await context.Characters.Select(c => new CharacterResponse{
            Name = c.Name,
            Game = c.Game,
            Role = c.Role
        }).ToListAsync();

        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
        {
            var result = await context.Characters
                .Where(c => c.Id == id)
                .Select(c => new CharacterResponse
                {
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                })
                .FirstOrDefaultAsync();

            return result;
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
