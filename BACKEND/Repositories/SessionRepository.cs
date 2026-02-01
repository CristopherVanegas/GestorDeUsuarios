using BACKEND.Data;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Repositories
{
    public class SessionRepository
    {
        private readonly ApplicationDbContext _context;

        public SessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LoginAsync(int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Session_Login @usuario_id = {0}",
                usuarioId
            );
        }

        public async Task LogoutAsync(int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Session_Logout @usuario_id = {0}",
                usuarioId
            );
        }
    }
}
