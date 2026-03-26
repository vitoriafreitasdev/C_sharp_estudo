
using API_PIMV.Dtos;
using API_PIMV.Models;
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
        public async Task<ActionResult<List<UsersGetResponse>>> Getusers()
        {
           try
           {
               return Ok(await service.GetAllUsers());
           }
           catch (Exception ex)
           {
                return BadRequest(ex.Message);
           }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsersGetResponse?>> GetUserById(int id)
        {
            try
            {
                var user = await service.GetUsers(id);

                return Ok(user);
                
                

            }
            catch (Exception ex)
            {
                if(ex.Message == "Usuário não encontrado.")
                {
                    return NotFound("User não encontrado.");
                }

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserRegisterResponse>> PostUser(UsersRegisterRequest user)
        {
            try
            {
                var newUser = await service.RegisterUser(user);
                return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserLoginResponse>> Login(UserLoginRequest user)
        {
            try
            {
                var requestReturn = await service.LoginUser(user);
                return Ok(requestReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
