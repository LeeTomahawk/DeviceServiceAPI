using Aplication.Dtos;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkplaceController : ControllerBase
    {
        private readonly IWorkplaceService _service;
        public WorkplaceController(IWorkplaceService service)
        {
            _service = service;
        }

        // GET: api/<WorplaceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkplaceDto>>> GetAll()
        {
            var workplaces = await _service.GetWorkplaces();
            return Ok(workplaces);
        }

        // GET api/<WorplaceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkplaceDto>> Get([FromRoute] Guid id)
        {
            var workplace = await _service.GetWorkPlaceById(id);
            return Ok(workplace);
        }

        // POST api/<WorplaceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WorplaceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WorplaceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
