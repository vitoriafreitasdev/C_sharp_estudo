
using API_PIMV.Dtos;
using API_PIMV.Helpers;
using API_PIMV.Models;
using API_PIMV.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

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
        [Authorize]
        public async Task<ActionResult<UsersGetResponse?>> GetUserById(int id)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandlerWrapper();
               
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                Console.WriteLine(token);

                // Validate the JWT and retrieve claims about the user.
                var claimsPrincipal = tokenHandler.ValidateJwtToken(token);

                // Check if the user is authenticated. If not, return an unauthorized response.
                if (claimsPrincipal?.Identity?.IsAuthenticated != true)
                {
                    return Unauthorized("Token has expired.");
                }
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

//https://akashjwork.medium.com/mastering-jwt-authorization-in-asp-net-core-7-with-automation-for-clean-code-and-efficiency-4259647de025