using API.Models;
using API.Services;
using API.Dtos;

namespace API.Services
{
    public interface IVideoGamesCharacterService
    {
        Task<List<CharacterResponse>> GetAllCharactersAsync();
        Task<CharacterResponse?> GetCharacterByIdAsync(int id);
        Task<CharacterResponse> AddCharacterByIdAsync(CreateCharacterRequest character);
        Task<bool> UpdateCharacterAsync(int id, UptadeCharacterRequest character);
        Task<bool> DeleteCharacterAsync(int id);

    }
}
