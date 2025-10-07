using BACKEND.Models;
using BACKEND.Repositories;

namespace BACKEND.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;

        public UsuarioService(UsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Usuario> GetUsuarioAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync() =>
            await _repository.GetAllAsync();

        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            // Aquí puedes agregar validaciones: correo único, password, etc.
            await _repository.CreateAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(Usuario usuario) =>
            await _repository.UpdateAsync(usuario);

        public async Task DeleteUsuarioAsync(int id) =>
            await _repository.DeleteAsync(id);
    }

}
