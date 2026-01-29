using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;
using BACKEND.Services;
using BACKEND.DTOs;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        //Inyeccion de dependencias
        private readonly RolService _service;
        private readonly RolRolOpcionesService _rolRolOpcionesService;

        public RolController(
            RolService service,
            RolRolOpcionesService rolRolOpcionesService) 
        { 
            _service = service; 
            _rolRolOpcionesService = rolRolOpcionesService;
        }

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetRolesAsync());
        
        [HttpGet("{id}")] public async Task<IActionResult> GetById(int id) { var r = await _service.GetRolAsync(id); return r == null ? NotFound() : Ok(r); }
        
        [HttpPost] public async Task<IActionResult> Create([FromBody] Rol rol) { await _service.CreateRolAsync(rol); return CreatedAtAction(nameof(GetById), new { id = rol.IdRol }, rol); }
        
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] Rol rol) { rol.IdRol = id; await _service.UpdateRolAsync(rol); return NoContent(); }
        
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _service.DeleteRolAsync(id); return NoContent(); }
        
        [HttpGet("{rolId}/opciones")]
        public async Task<IActionResult> GetOpciones(int rolId)
        {
            var result = await _rolRolOpcionesService.GetDetalleByRolAsync(rolId);
            return Ok(result);
        }

        [HttpPost("{rolId}/opciones")]
        public async Task<IActionResult> AddOpcion(
            int rolId,
            [FromBody] RolOpcionesAddDto dto)
        {
            var item = new RolRolOpcione
            {
                RolIdRol = rolId,
                RolOpcionesIdOpciones = dto.OpcionId
            };

            await _rolRolOpcionesService.CreateAsync(item);
            return Ok();
        }
    }
}
