
using API_PIMV.Dtos;
using API_PIMV.Models;
using API_PIMV.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_PIMV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController(ISiteService service) : Controller
    {
        [HttpPost("addComment")]
        public async Task<ActionResult<Comments>> AddingComments(AddComentRequest comment)
        {
            try
            {
                var requestReturn = await service.AddComent(comment);

                if (requestReturn != null)
                {
                    return Ok(requestReturn);
                }

                return BadRequest(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("comments/{eventId}")]
        public async Task<ActionResult<List<CommentsRes>>> ShowingEventComments(int eventId)
        {
            try
            {
                var requestReturn = await service.ShowComments(eventId);

                return Ok(requestReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("registerToEvent")]
        public async Task<ActionResult<bool>> EventRegister(DeleteRegistEventRequest request)
        {
            try
            {
                var requestReturn = await service.RegisterToEvent(request);

                return Ok(requestReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("registeredUsersInEvent/{eventId}")]
        public async Task<ActionResult<List<UserRegisteredEvent>>> getUsersRegisteredInEvent(int eventId)
        {
            try
            {
                var requestReturn = await service.UsersReginterInTheEvent(eventId);

                return Ok(requestReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
