
// controller
using API.Models;

using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharactersController(IVideoGamesCharacterService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<CharacterResponse>>> GetCharacter()
            => Ok(await service.GetAllCharactersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponse>> GetCharacter(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);

            return character is null ? NotFound("Character with the given Id was not found.") : Ok(character);
            //if(character is null)
            //{
            //    return NotFound("Character with the given Id was not found.");
            //}
            //return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<CharacterResponse>> AddCharacter(CreateCharacterRequest character)
        {
            var createCharacter = await service.AddCharacterByIdAsync(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = createCharacter.Id }, createCharacter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UptadeCharacter(int id, UptadeCharacterRequest character)
        {
            var uptade = await service.UpdateCharacterAsync(id, character);
            return uptade ? NoContent() : NotFound("Character with the given id was not found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var deleted = await service.DeleteCharacterAsync(id);
            return deleted ? NoContent() : NotFound("Character with the given id was not found");
        }
    }
}
