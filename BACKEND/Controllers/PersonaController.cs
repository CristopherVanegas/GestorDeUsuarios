using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;
using BACKEND.Services;
using BACKEND.DTOs;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : Controller
    {
        private readonly PersonaService _personaService;

        public PersonaController(PersonaService personaService)
        {
            _personaService = personaService;
        }

        // GET: api/persona
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personas = await _personaService.GetPersonasAsync();
            return Ok(personas);
        }

        // GET: api/persona/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var persona = await _personaService.GetPersonaAsync(id);
            if (persona == null)
                return NotFound();
            return Ok(persona);
        }

        // POST: api/persona
        [HttpPost]
        public async Task<IActionResult> Create(PersonaCreateDto dto)
        {
            var persona = new Persona
            {
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                Identificacion = dto.Identificacion,
                FechaNacimiento = dto.FechaNacimiento
            };

            var result = await _personaService.CreatePersonaAsync(persona);
            return Ok(result);
        }

        // PUT: api/persona/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PersonaUpdateDto dto)
        {
            var persona = await _personaService.GetPersonaAsync(id);
            if (persona == null)
                return NotFound();

            persona.Nombres = dto.Nombres;
            persona.Apellidos = dto.Apellidos;
            persona.Identificacion = dto.Identificacion;
            persona.FechaNacimiento = dto.FechaNacimiento;

            await _personaService.UpdatePersonaAsync(persona);
            return NoContent();
        }

        // DELETE: api/persona/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personaService.DeletePersonaAsync(id);
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, PersonaStatusDto dto)
        {
            if (dto.Status != "A" && dto.Status != "I")
                return BadRequest("Status inválido");

            var persona = await _personaService.GetPersonaIncludingInactiveAsync(id);
            if (persona == null)
                return NotFound();

            persona.Status = dto.Status;
            await _personaService.UpdatePersonaAsync(persona);

            return NoContent();
        }
    }
}
