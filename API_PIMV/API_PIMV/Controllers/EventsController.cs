using API_PIMV.Classes;
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

        //[HttpGet("getEventByUser/{userId}")]
        //public async Task<ActionResult<List<GetUserEventResponse?>>> GetUserEvent(int userId)
        //{
        //    try
        //    {
        //        var eventReturned = await service.GetEventsRegisteredByUser(userId);

        //        return Ok(eventReturned);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost("AddEvent")]
        public async Task<ActionResult<Events>> AddingEvent(AddEventRequest eventObj)
        {
            try
            {
                var eventAdd = await service.AddEvent(eventObj);

                return CreatedAtAction(nameof(GetEvent), new { id = eventAdd.Id }, eventAdd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("EditEvent")]
        public async Task<ActionResult<Events>> EventEdit(Events events)
        {
            try
            {
                var eventEdit = await service.EditEvent(events);

                return CreatedAtAction(nameof(GetEvent), new { id = eventEdit.Id }, eventEdit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteEvent")]
        public async Task<ActionResult<bool>> DelEvent(DeleteRegistEventRequest request)
        {
            try
            {
                var eventDel = await service.DeleteEvent(request);
                return Ok(eventDel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetCertificateData")]
        public async Task<ActionResult<Certificate>> CertificateData(CertificateRequest certificateBody)
        {
            try
            {
                var certificate = await service.Certificate(certificateBody);

                return Ok(certificate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
