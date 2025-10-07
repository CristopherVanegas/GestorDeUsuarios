using BACKEND.Data;
using BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Repositories
{
    public class RolUsuariosRepository
    {
        private readonly ApplicationDbContext _context;
        public RolUsuariosRepository(ApplicationDbContext context) { _context = context; }

        public async Task<IEnumerable<RolUsuario>> GetAllAsync() => await _context.RolUsuarios.ToListAsync();
        public async Task CreateAsync(RolUsuario r) { _context.RolUsuarios.Add(r); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int rolId, int usuarioId)
        {
            var item = await _context.RolUsuarios
                .FirstOrDefaultAsync(x => x.RolIdRol == rolId && x.UsuarioIdUsuario == usuarioId);
            if (item != null) { _context.RolUsuarios.Remove(item); await _context.SaveChangesAsync(); }
        }
    }
}
