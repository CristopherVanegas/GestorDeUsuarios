using BACKEND.Constants;
using BACKEND.Data;
using BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Repositories
{
    public class UsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.PersonaIdPersona2Navigation)
                .FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync() =>
            await _context.Usuarios.ToListAsync();

        public async Task CreateAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                usuario.Status = StatusConst.Inactivo;
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Usuario?> GetByIdWithPersonaAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.PersonaIdPersona2Navigation)
                .FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

    }
}
