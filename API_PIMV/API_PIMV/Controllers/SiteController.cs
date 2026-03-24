
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
        public async Task<ActionResult<bool>> AddingComments(Comments comment)
        {
            try
            {
                var requestReturn = await service.AddComent(comment.EventId, comment.UserId, comment.Commentary);

                if (requestReturn == true)
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

        [HttpGet("comments")]
        public async Task<ActionResult<List<Comments>>> ShowingEventComments(int eventId)
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
        public async Task<ActionResult<bool>> EventRegister(int eventId, int userId)
        {
            try
            {
                var requestReturn = await service.RegisterToEvent(eventId, userId);

                return Ok(requestReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("registeredUsersInEvent")]
        public async Task<ActionResult<List<UsersGetResponse>>> getUsersRegisteredInEvent(int eventId)
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
