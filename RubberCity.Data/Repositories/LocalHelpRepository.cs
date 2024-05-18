using Domain.Models;
using Microsoft.EntityFrameworkCore;
using RubberCity.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RubberCity.Data.Repositories
{
    public class LocalHelpRepository : ILocalHelpRepository<LocalHelp>
    {
        private readonly DbContext _context;

        public LocalHelpRepository(DbContext context)
        {
            _context = context;
        }

        public async Task Add(LocalHelp entity)
        {
            _context.Set<LocalHelp>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LocalHelp>> GetAll()
        {
            return await _context.Set<LocalHelp>().ToListAsync();
        }

        public async Task<LocalHelp> GetById(int id)
        {
            return await _context.Set<LocalHelp>().FindAsync(id);
        }

        public async Task Update(LocalHelp entity)
        {
            _context.Set<LocalHelp>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(LocalHelp entity)
        {
            _context.Set<LocalHelp>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
