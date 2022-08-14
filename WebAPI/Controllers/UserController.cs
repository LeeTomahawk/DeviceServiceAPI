using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repositories.Dtos;
using System.Net;

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
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginDto logindto)
        {
            var token = await _service.GenerateJwt(logindto);
            var res = new LoginResponse();
            res.Token = token;
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await _service.GetUserById(id);
            return Ok(user);
        }
    }
}
