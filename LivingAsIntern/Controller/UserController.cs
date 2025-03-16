using LivingAsIntern.DTO;
using LivingAsIntern.Entities;
using LivingAsIntern.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingAsIntern.Controller
{
    [ApiController]
    [Route("api/admin")]
    public class UserController : ControllerBase
    {
        private UserServiceDb _serviceDb;
        private UserServiceToken _serviceToken = new UserServiceToken();

        public UserController(UserServiceDb userServiceDb)
        {
            _serviceDb = userServiceDb;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var user = await _serviceDb.GetUserByUsername(request.Username);

            if (user == null)
            {
                return BadRequest("Username or Password not found!");
            }

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, request.Password) == PasswordVerificationResult.Failed)
            {
                return BadRequest("Username or Password Wrong!");
            }

            string token = _serviceToken.GenerateToken(user);

            return Ok(token);
        }
    }
}
