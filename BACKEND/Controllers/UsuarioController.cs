using BACKEND.Constants;
using BACKEND.DTOs;
using BACKEND.Models;
using BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _service.GetUsuarioDetalleAsync(id);
            return usuario == null ? NotFound() : Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioCreateDto dto)
        {
            try
            {
                var usuario = new Usuario
                {
                    UserName = dto.UserName,
                    Passcode = dto.Passcode,
                    Mail = dto.Mail,
                    PersonaIdPersona2 = dto.PersonaIdPersona2,
                    SessionActive = "I",
                    Status = "A"
                };

                await _service.CreateUsuarioAsync(usuario);
                return Ok();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioUpdateDto dto)
        {
            try
            {
                await _service.UpdateUsuarioAsync(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteUsuarioAsync(id);
            return Ok();
        }
    }
}
