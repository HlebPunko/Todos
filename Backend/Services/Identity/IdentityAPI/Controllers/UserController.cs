using Identity.Application.Models;
using Identity.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly string SecretKey = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJOMZ4zY";//TODO delete it!
        private static readonly string Issuer = "http://localhost:5103";
        private static readonly string Audience = "http://localhost:5103";
        private readonly IAuthService _service;

        public UserController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel registerModel)
        {
            if (await _service.RegisterAsync(registerModel))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync([FromBody] LoginModel loginModel)
        {
            if (await _service.LoginAsync(loginModel))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
