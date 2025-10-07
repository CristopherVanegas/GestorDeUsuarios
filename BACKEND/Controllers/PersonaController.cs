using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;
using BACKEND.Services;

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
        public async Task<IActionResult> Create([FromBody] Persona persona)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _personaService.CreatePersonaAsync(persona);
            return CreatedAtAction(nameof(GetById), new { id = persona.IdPersona }, persona);
        }

        // PUT: api/persona/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Persona persona)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            persona.IdPersona = id;
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
    }
}
