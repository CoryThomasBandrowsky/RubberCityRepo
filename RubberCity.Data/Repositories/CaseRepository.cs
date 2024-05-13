using Domain.Models;
using Microsoft.EntityFrameworkCore;
using RubberCity.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubberCity.Data.Repositories
{
    public class CaseRepository : IRepository<Case>
    {
        private readonly DbContext _context;

        public CaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task Add(Case entity)
        {
            _context.Set<Case>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Case>> GetAll()
        {
            return await _context.Set<Case>().ToListAsync();
        }

        public async Task<IEnumerable<Case>> GetAllActive()
        {
            return await _context.Set<Case>().Where(x => x.IsActive).ToListAsync();
        }

        public async Task<Case> GetById(int id)
        {
            return await _context.Set<Case>().FindAsync(id);
        }

        public async Task Update(Case entity)
        {
            _context.Set<Case>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Case entity)
        {
            _context.Set<Case>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
