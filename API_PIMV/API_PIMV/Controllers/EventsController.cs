using API_PIMV.Dtos;
using API_PIMV.Models;
using API_PIMV.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_PIMV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController(IEventsServices service) : Controller
    {
        [HttpGet("getEvents")]
        public async Task<ActionResult<List<EventsResponse>>> GetAllEvents()
        {
            try
            {
                var requestRes = await service.GetEvents();

                return Ok(requestRes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getEvent/{id}")]
        public async Task<ActionResult<EventsResponse?>> GetEvent(int Id)
        {
            try
            {
                var eventReturned = await service.GetEventById(Id);

                return Ok(eventReturned);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getEventByUser")]
        public async Task<ActionResult<List<GetUserEventResponse?>>> GetUserEvent(int userId)
        {
            try
            {
                var eventReturned = await service.GetEventsRegisteredByUser(userId);

                return Ok(eventReturned);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
