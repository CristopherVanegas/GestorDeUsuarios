using BACKEND.Data;
using BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Repositories
{
    public class RolRepository
    {
        private readonly ApplicationDbContext _context;

        public RolRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> GetAllAsync() => await _context.Rols.ToListAsync();
        public async Task<Rol> GetByIdAsync(int id) => await _context.Rols.FindAsync(id);
        public async Task CreateAsync(Rol rol) { _context.Rols.Add(rol); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Rol rol) { _context.Rols.Update(rol); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var rol = await _context.Rols.FindAsync(id);
            if (rol != null) { rol.Status = "INACTIVO"; _context.Rols.Update(rol); await _context.SaveChangesAsync(); }
        }
    }
}
