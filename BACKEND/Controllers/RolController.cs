using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;
using BACKEND.Services;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly RolService _service;
        public RolController(RolService service) { _service = service; }

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetRolesAsync());
        [HttpGet("{id}")] public async Task<IActionResult> GetById(int id) { var r = await _service.GetRolAsync(id); return r == null ? NotFound() : Ok(r); }
        [HttpPost] public async Task<IActionResult> Create([FromBody] Rol rol) { await _service.CreateRolAsync(rol); return CreatedAtAction(nameof(GetById), new { id = rol.IdRol }, rol); }
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] Rol rol) { rol.IdRol = id; await _service.UpdateRolAsync(rol); return NoContent(); }
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _service.DeleteRolAsync(id); return NoContent(); }
    }
}
