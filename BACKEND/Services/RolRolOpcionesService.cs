using BACKEND.DTOs;
using BACKEND.Models;
using BACKEND.Repositories;

namespace BACKEND.Services
{
    public class RolRolOpcionesService
    {
        private readonly RolRolOpcionesRepository _repository;

        public RolRolOpcionesService(RolRolOpcionesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RolRolOpcione>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task CreateAsync(RolRolOpcione r) => await _repository.CreateAsync(r);

        public async Task DeleteAsync(int rolId, int opcionId) =>
            await _repository.DeleteAsync(rolId, opcionId);

        public async Task<IEnumerable<RolRolOpcione>> GetByRolAsync(int rolId)
        {
            return await _repository.GetByRolAsync(rolId);
        }

        public async Task UpdateAsync(int rolId, int opcionAnteriorId, int opcionNuevaId)
        {
            await _repository.UpdateAsync(rolId, opcionAnteriorId, opcionNuevaId);
        }

        public async Task<IEnumerable<RolConOpcionDto>> GetDetalleByRolAsync(int rolId)
        {
            return await _repository.GetDetalleByRolAsync(rolId);
        }
    }
}
