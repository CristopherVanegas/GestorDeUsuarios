using BACKEND.Models;
using BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolRolOpcionesController : ControllerBase
    {
        private readonly RolRolOpcionesService _service;

        public RolRolOpcionesController(RolRolOpcionesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolRolOpcione r)
        {
            await _service.CreateAsync(r);
            return Ok(r);
        }

        [HttpDelete("{rolId}/{opcionId}")]
        public async Task<IActionResult> Delete(int rolId, int opcionId)
        {
            await _service.DeleteAsync(rolId, opcionId);
            return NoContent();
        }
    }
}
