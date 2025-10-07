using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;
using BACKEND.Services;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolOpcionesController : ControllerBase
    {
        private readonly RolOpcionesService _service;
        public RolOpcionesController(RolOpcionesService service) { _service = service; }

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
        [HttpGet("{id}")] public async Task<IActionResult> GetById(int id) { var r = await _service.GetByIdAsync(id); return r == null ? NotFound() : Ok(r); }
        [HttpPost] public async Task<IActionResult> Create([FromBody] RolOpcione r) { await _service.CreateAsync(r); return CreatedAtAction(nameof(GetById), new { id = r.IdOpcion }, r); }
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] RolOpcione r) { r.IdOpcion = id; await _service.UpdateAsync(r); return NoContent(); }
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _service.DeleteAsync(id); return NoContent(); }
    }
}
