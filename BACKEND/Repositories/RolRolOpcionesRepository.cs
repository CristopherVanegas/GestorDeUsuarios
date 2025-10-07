using BACKEND.Data;
using BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Repositories
{
    public class RolRolOpcionesRepository
    {
        private readonly ApplicationDbContext _context;
        public RolRolOpcionesRepository(ApplicationDbContext context) { _context = context; }

        public async Task<IEnumerable<RolRolOpcione>> GetAllAsync() => await _context.RolRolOpciones.ToListAsync();
        public async Task CreateAsync(RolRolOpcione r) { _context.RolRolOpciones.Add(r); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int rolId, int opcionId)
        {
            var item = await _context.RolRolOpciones
                .FirstOrDefaultAsync(x => x.RolIdRol == rolId && x.RolOpcionesIdOpciones == opcionId);
            if (item != null) { _context.RolRolOpciones.Remove(item); await _context.SaveChangesAsync(); }
        }
    }
}
