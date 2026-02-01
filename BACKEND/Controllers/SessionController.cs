using BACKEND.DTOs;
using BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly SessionService _service;

        public SessionController(SessionService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SessionLoginDto dto)
        {
            try
            {
                await _service.LoginAsync(dto.UsuarioIdUsuario);
                return Ok(new { message = "Sesión iniciada correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] SessionLoginDto dto)
        {
            await _service.LogoutAsync(dto.UsuarioIdUsuario);
            return Ok(new { message = "Sesión cerrada correctamente" });
        }
    }
}
