
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

        [HttpGet("^{id}")]
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
    }
}
