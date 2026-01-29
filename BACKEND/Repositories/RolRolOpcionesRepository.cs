using BACKEND.Data;
using BACKEND.DTOs;
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

        public async Task<IEnumerable<RolRolOpcione>> GetByRolAsync(int rolId)
        {
            return await _context.RolRolOpciones
                .Where(x => x.RolIdRol == rolId)
                .ToListAsync();
        }

        public async Task UpdateAsync(int rolId, int opcionAnteriorId, int opcionNuevaId)
        {
            var oldItem = await _context.RolRolOpciones
                .FirstOrDefaultAsync(x =>
                    x.RolIdRol == rolId &&
                    x.RolOpcionesIdOpciones == opcionAnteriorId);

            if (oldItem == null)
                throw new Exception("Relación no encontrada");

            _context.RolRolOpciones.Remove(oldItem);

            var newItem = new RolRolOpcione
            {
                RolIdRol = rolId,
                RolOpcionesIdOpciones = opcionNuevaId
            };

            _context.RolRolOpciones.Add(newItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RolConOpcionDto>> GetDetalleByRolAsync(int rolId)
        {
            return await _context.RolRolOpciones
                .Where(x => x.RolIdRol == rolId)
                .Select(x => new RolConOpcionDto
                {
                    RolId = x.RolIdRol,
                    RolNombre = x.RolIdRolNavigation.RolName,
                    OpcionId = x.RolOpcionesIdOpciones,
                    OpcionNombre = x.RolOpcionesIdOpcionesNavigation.NombreOpciones
                })
                .ToListAsync();
        }
    }
}
