using BACKEND.Data;
using BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Repositories
{
    public class RolOpcionesRepository
    {
        private readonly ApplicationDbContext _context;
        public RolOpcionesRepository(ApplicationDbContext context) { _context = context; }

        public async Task<IEnumerable<RolOpcione>> GetAllAsync() => await _context.RolOpciones.ToListAsync();
        public async Task<RolOpcione> GetByIdAsync(int id) => await _context.RolOpciones.FindAsync(id);
        public async Task CreateAsync(RolOpcione r) { _context.RolOpciones.Add(r); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(RolOpcione r) { _context.RolOpciones.Update(r); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id) { var r = await _context.RolOpciones.FindAsync(id); if (r != null) { r.Status = "INACTIVO"; _context.RolOpciones.Update(r); await _context.SaveChangesAsync(); } }
    }
}
