using BACKEND.Models;
using BACKEND.Repositories;

namespace BACKEND.Services
{
    public class RolOpcionesService
    {
        private readonly RolOpcionesRepository _repository;
        public RolOpcionesService(RolOpcionesRepository repo) { _repository = repo; }

        public async Task<IEnumerable<RolOpcione>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<RolOpcione> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task CreateAsync(RolOpcione r) => await _repository.CreateAsync(r);
        public async Task UpdateAsync(RolOpcione r) => await _repository.UpdateAsync(r);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
