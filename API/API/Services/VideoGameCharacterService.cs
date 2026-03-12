using API.Models;

namespace API.Services
{
    public class VideoGameCharacterService : IVideoGamesCharacterService
    {
        static List<Character> characters = new List<Character> {
            new Character {Id = 1, Name = "Mario", Game = "Super Mario Bros", Role = "Hero"},
            new Character {Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Hero"},
            new Character {Id = 3, Name = "Browser", Game = "Super Mario Bros", Role = "Villain"},
            new Character {Id = 4, Name = "Zelda", Game = "The Legend of Zelda", Role = "Princess"},
        };

        public Task<Character> AddCharacterByIdAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Character>> GetAllCharactersAsync()
            => await Task.FromResult(characters);

        public async Task<Character?> GetCharacterByIdAsync(int id)
        {
            var result = characters.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(result);
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
