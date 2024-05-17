using Domain.Models;
using Microsoft.EntityFrameworkCore;
using RubberCity.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RubberCity.Data.Repositories
{
    public class EventRepository : IEventRepository<Event>
    {
        private readonly DbContext _context;

        public EventRepository(DbContext context)
        {
            _context = context;
        }

        public async Task Add(Event entity)
        {
            _context.Set<Event>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Set<Event>().ToListAsync();
        }

        public async Task<Event> GetById(int id)
        {
            return await _context.Set<Event>().FindAsync(id);
        }

        public async Task Update(Event entity)
        {
            _context.Set<Event>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Event entity)
        {
            _context.Set<Event>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
