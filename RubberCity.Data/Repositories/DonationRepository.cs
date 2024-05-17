using Domain.Models;
using Microsoft.EntityFrameworkCore;
using RubberCity.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RubberCity.Data.Repositories
{
    public class DonationRepository : IDonationRepository<Donation>
    {
        private readonly DbContext _context;

        public DonationRepository(DbContext context)
        {
            _context = context;
        }

        public async Task Add(Donation entity)
        {
            _context.Set<Donation>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Donation>> GetAll()
        {
            return await _context.Set<Donation>().ToListAsync();
        }

        public async Task<Donation> GetById(int id)
        {
            return await _context.Set<Donation>().FindAsync(id);
        }

        public async Task Update(Donation entity)
        {
            _context.Set<Donation>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Donation entity)
        {
            _context.Set<Donation>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
