using BACKEND.Repositories;

namespace BACKEND.Services
{
    public class SessionService
    {
        private readonly SessionRepository _repository;

        public SessionService(SessionRepository repository)
        {
            _repository = repository;
        }

        public async Task LoginAsync(int usuarioId)
        {
            await _repository.LoginAsync(usuarioId);
        }

        public async Task LogoutAsync(int usuarioId)
        {
            await _repository.LogoutAsync(usuarioId);
        }
    }
}
