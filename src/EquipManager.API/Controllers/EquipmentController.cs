using EquipManager.Application.Services;
using EquipManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EquipManager.API.Controllers
{
    // Define a rota base do controller: /api/equipment
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        // Campo para acessar o serviço
        private readonly EquipmentService _service;

        // Construtor: o ASP.NET injeta automaticamente o serviço aqui
        public EquipmentController(EquipmentService service)
        {
            _service = service;
        }

        // GET: /api/equipment
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.ListAllAsync();
            return Ok(result);
        }

        // GET: /api/equipment/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var equipment = await _service.GetByIdAsync(id);
            if (equipment == null)
                return NotFound("Equipamento não encontrado.");

            return Ok(equipment);
        }

        // POST: /api/equipment
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Equipment equipment)
        {
            await _service.AddAsync(equipment);
            return CreatedAtAction(nameof(GetById), new { id = equipment.Id }, equipment);
        }

        // PUT: /api/equipment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Equipment equipment)
        {
            if (id != equipment.Id)
                return BadRequest("ID do corpo e da rota não coincidem.");

            await _service.UpdateAsync(equipment);
            return NoContent();
        }

        // DELETE: /api/equipment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
