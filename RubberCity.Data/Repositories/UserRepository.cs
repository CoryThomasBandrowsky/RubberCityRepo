using Domain.Models;
using Microsoft.EntityFrameworkCore;
using RubberCity.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubberCity.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public async Task Add(User entity)
        {
            _context.Set<User>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Set<User>().ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Set<User>().FindAsync(id);
        }

        public async Task Update(User entity)
        {
            _context.Set<User>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            _context.Set<User>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
