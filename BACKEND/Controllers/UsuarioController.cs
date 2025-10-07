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
            var usuario = await _service.GetUsuarioAsync(id);
            return usuario == null ? NotFound() : Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            await _service.CreateUsuarioAsync(usuario);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            usuario.IdUsuario = id;
            await _service.UpdateUsuarioAsync(usuario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteUsuarioAsync(id);
            return Ok();
        }
    }
}
