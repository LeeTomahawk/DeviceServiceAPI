using Aplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegisterUserDto>> Register([FromBody] RegisterUserDto user)
        {
            await _service.Adduser(user);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto logindto)
        {
            var token = await _service.GenerateJwt(logindto);
            return Ok(token);
        }
    }
}
