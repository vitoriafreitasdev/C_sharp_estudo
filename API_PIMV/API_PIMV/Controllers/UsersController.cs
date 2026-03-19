
using API_PIMV.Dtos;
using API_PIMV.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_PIMV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsersServices service) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<UsersGetResponse>>> Getusers() => Ok(await service.GetAllUsers());

        [HttpGet("{id}")]
        public async Task<ActionResult<UsersGetResponse?>> GetUserById(int id)
        {
            var user = await service.GetUsers(id);

            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User not found");
        }

    }
}
