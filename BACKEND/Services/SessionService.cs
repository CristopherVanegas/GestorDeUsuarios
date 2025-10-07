using BACKEND.Models;
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

        public async Task<IEnumerable<Session>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Session> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task CreateAsync(Session s) => await _repository.CreateAsync(s);
        public async Task UpdateAsync(Session s) => await _repository.UpdateAsync(s);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
