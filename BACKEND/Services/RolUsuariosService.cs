using BACKEND.Models;
using BACKEND.Repositories;

namespace BACKEND.Services
{
    public class RolUsuariosService
    {
        private readonly RolUsuariosRepository _repository;

        public RolUsuariosService(RolUsuariosRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RolUsuario>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task CreateAsync(RolUsuario r) => await _repository.CreateAsync(r);

        public async Task DeleteAsync(int rolId, int usuarioId) =>
            await _repository.DeleteAsync(rolId, usuarioId);
    }
}
