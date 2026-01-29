using BACKEND.Data;
using BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Repositories
{
    public class PersonaRepository
    {
        private readonly ApplicationDbContext _context;

        // Inyección de dependencias del DbContext
        public PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todas las personas
        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas
                .Where(p => p.Status == "A")
                .ToListAsync();
        }

        // Obtener persona por ID
        public async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas
                .FirstOrDefaultAsync(p => p.IdPersona == id && p.Status == "A");
        }

        // Crear una persona
        public async Task CreateAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }

        // Actualizar una persona
        public async Task UpdateAsync(Persona persona)
        {
            _context.Personas.Update(persona);
            await _context.SaveChangesAsync();
        }

        // Eliminación lógica (cambiar Status si tu tabla tiene un campo Status)
        public async Task DeleteAsync(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null) return;

            persona.Status = "I"; // o "INACTIVO"
            await _context.SaveChangesAsync();
        }

        public async Task<Persona> GetByIdIncludingInactiveAsync(int id)
        {
            return await _context.Personas
                .FirstOrDefaultAsync(p => p.IdPersona == id);
        }
    }
}
