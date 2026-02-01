using BACKEND.Constants;
using BACKEND.DTOs;
using BACKEND.Models;
using BACKEND.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

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
        public async Task<IActionResult> Put(int id, UsuarioUpdateDto dto)
        {
            try
            {
                var updated = await _service.UpdateParcialAsync(id, dto);

                if (!updated)
                    return NotFound(new { message = $"Usuario con id {id} no existe" });

                return Ok(new { message = "Usuario actualizado con éxito" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
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
