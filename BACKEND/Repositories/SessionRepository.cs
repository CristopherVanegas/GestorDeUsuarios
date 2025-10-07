using BACKEND.Data;
using BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Repositories
{
    public class SessionRepository
    {
        private readonly ApplicationDbContext _context;
        public SessionRepository(ApplicationDbContext context) { _context = context; }

        public async Task<IEnumerable<Session>> GetAllAsync() => await _context.Sessions.ToListAsync();
        public async Task<Session> GetByIdAsync(int id) => await _context.Sessions.FindAsync(id);
        public async Task CreateAsync(Session s) { _context.Sessions.Add(s); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Session s) { _context.Sessions.Update(s); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var s = await _context.Sessions.FindAsync(id);
            if (s != null) { s.Status = "INACTIVO"; _context.Sessions.Update(s); await _context.SaveChangesAsync(); }
        }
    }
}
