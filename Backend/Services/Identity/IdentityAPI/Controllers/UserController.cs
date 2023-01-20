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
