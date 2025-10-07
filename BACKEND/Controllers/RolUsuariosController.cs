using BACKEND.Models;
using BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolUsuariosController : ControllerBase
    {
        private readonly RolUsuariosService _service;

        public RolUsuariosController(RolUsuariosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolUsuario r)
        {
            await _service.CreateAsync(r);
            return Ok(r);
        }

        [HttpDelete("{rolId}/{usuarioId}")]
        public async Task<IActionResult> Delete(int rolId, int usuarioId)
        {
            await _service.DeleteAsync(rolId, usuarioId);
            return NoContent();
        }
    }
}
