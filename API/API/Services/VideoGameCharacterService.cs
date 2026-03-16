
// services
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using API.Dtos;

namespace API.Services
{
    public class VideoGameCharacterService(AppDbContext context) : IVideoGamesCharacterService
    {

        public async Task<CharacterResponse> AddCharacterByIdAsync(CreateCharacterRequest character)
        {
            var newCharacter = new Character
            { 
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            };

            context.Characters.Add(newCharacter);
            await context.SaveChangesAsync();

            return new CharacterResponse
            {
                Id = newCharacter.Id,
                Name = newCharacter.Name,
                Game = newCharacter.Game,
                Role = newCharacter.Role
            };

        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var characterToDelete = await context.Characters.FindAsync(id);
            if (characterToDelete is null) return false;

            context.Characters.Remove(characterToDelete);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<List<CharacterResponse>> GetAllCharactersAsync()
            => await context.Characters.Select(c => new CharacterResponse{
            Id = c.Id,
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
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> UpdateCharacterAsync(int id, UptadeCharacterRequest character)
        {
            var existingCharacter = await context.Characters.FindAsync(id);
            if (existingCharacter is null) return false;

            existingCharacter.Name = character.Name;
            existingCharacter.Game = character.Game;
            existingCharacter.Role = character.Role;

            await context.SaveChangesAsync();

            return true;
        }
    }
}
