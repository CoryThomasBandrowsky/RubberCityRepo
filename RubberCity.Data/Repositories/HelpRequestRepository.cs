using Domain.Models;
using Microsoft.EntityFrameworkCore;
using RubberCity.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubberCity.Data.Repositories
{
    public class HelpRequestRepository : IRepository<HelpRequestModel>
    {
        private readonly DbContext _context;

        public HelpRequestRepository(DbContext context)
        {
            _context = context;
        }

        public async Task Add(HelpRequestModel entity)
        {
            _context.Set<HelpRequestModel>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HelpRequestModel>> GetAll()
        {
            return await _context.Set<HelpRequestModel>().ToListAsync();
        }

        public async Task<HelpRequestModel> GetById(int id)
        {
            return await _context.Set<HelpRequestModel>().FindAsync(id);
        }

        public async Task Update(HelpRequestModel entity)
        {
            _context.Set<HelpRequestModel>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(HelpRequestModel entity)
        {
            _context.Set<HelpRequestModel>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<HelpRequestModel>> GetAllActive()
        {
            throw new NotImplementedException();
        }
    }
}
