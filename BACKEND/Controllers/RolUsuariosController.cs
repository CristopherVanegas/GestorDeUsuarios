using BACKEND.DTOs;
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

        [HttpDelete("{usuarioId}/roles/{rolId}")]
        public async Task<IActionResult> RemoveRol(int usuarioId, int rolId)
        {
            await _service.DeleteAsync(rolId, usuarioId);
            return NoContent();
        }

        [HttpPost("{usuarioId}/roles")]
        public async Task<IActionResult> AddRol(
            int usuarioId,
            [FromBody] UsuarioRolAddDto dto)
        {
            var entity = new RolUsuario
            {
                UsuarioIdUsuario = usuarioId,
                RolIdRol = dto.RolId
            };

            await _service.CreateAsync(entity);
            return Ok();
        }
    }
}
