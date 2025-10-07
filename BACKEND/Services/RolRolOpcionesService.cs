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
    }
}
