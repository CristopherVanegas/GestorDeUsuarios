using BACKEND.Models;
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

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await _service.GetByIdAsync(id);
            if (s == null) return NotFound();
            return Ok(s);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Session s)
        {
            await _service.CreateAsync(s);
            return Ok(s);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Session s)
        {
            s.UsuarioIdUsuario = id; // o asigna el id correcto según tu lógica
            await _service.UpdateAsync(s);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
