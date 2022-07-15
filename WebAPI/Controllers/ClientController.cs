using Aplication.Dtos;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;
        public ClientController(IClientService service)
        {
            _service = service;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> Get()
        {
            var clients = await _service.GetClients();
            return Ok(clients);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> Get([FromRoute] Guid id)
        {
            var client = await _service.GetClient(id);
            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<ClientCreateDto>> Post([FromBody] ClientCreateDto client)
        {
            var c = await _service.AddClient(client);
            return Ok(c);
        }

        // PUT api/<ClientController>/5
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _service.DeleteClient(id);
            return Ok();
        }
    }
}
