using Repositories.Dtos;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _service;
        public EquipmentController(IEquipmentService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentDto>>> GetAll()
        {
            var eqs = await _service.GetEquipments();
            return Ok(eqs);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentDto>> GetById([FromRoute]Guid id)
        {
            var eq = await _service.GetEquipmentById(id);
            if(eq == null)
            {
                return NotFound();
            }
            return Ok(eq);
        }
        [HttpGet("~/api/Equipment/GetAvailableEquipment/{id}")]
        public async Task<ActionResult<EquipmentDto>> GetAvailableEquipment([FromRoute] Guid id)
        {
            var eq = await _service.GetEquipmentToWorkplace(id);
            return Ok(eq);
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] EquipmentCreateDto equipment)
        {
            var eq = await _service.AddEquipment(equipment);
            return Ok(eq);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] EquipmentUpdateDto equipment)
        {
            await _service.UpdateEquipment(equipment);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _service.DeleteEquipment(id);
            return Ok();
        }

    }
}
