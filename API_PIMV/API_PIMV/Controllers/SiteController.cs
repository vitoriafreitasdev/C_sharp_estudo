
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
                return BadRequest(ex);
            }
        }
    }
}
