using API.Models;
using API.Services;
using API.Dtos;

namespace API.Services
{
    public interface IVideoGamesCharacterService
    {
        Task<List<CharacterResponse>> GetAllCharactersAsync();
        Task<CharacterResponse?> GetCharacterByIdAsync(int id);
        Task<CharacterResponse> AddCharacterByIdAsync(Character character);
        Task<bool> UpdateCharacterAsync(int id, Character character);
        Task<bool> DeleteCharacterAsync(int id);

    }
}
