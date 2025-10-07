using BACKEND.Models;
using BACKEND.Repositories;

namespace BACKEND.Services
{
    public class RolService
    {
        private readonly RolRepository _repository;

        public RolService(RolRepository repository) { _repository = repository; }

        public async Task<IEnumerable<Rol>> GetRolesAsync() => await _repository.GetAllAsync();
        public async Task<Rol> GetRolAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task CreateRolAsync(Rol rol) => await _repository.CreateAsync(rol);
        public async Task UpdateRolAsync(Rol rol) => await _repository.UpdateAsync(rol);
        public async Task DeleteRolAsync(int id) => await _repository.DeleteAsync(id);
    }
}
