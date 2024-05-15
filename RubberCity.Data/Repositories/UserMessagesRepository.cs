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
    public class UserMessagesRepository : IRepository<UserMessage>
    {
        private readonly DbContext _context;

        public UserMessagesRepository(DbContext context)
        {
            _context = context;
        }

        public async Task Add(UserMessage entity)
        {
            _context.Set<UserMessage>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserMessage>> GetAll()
        {
            return await _context.Set<UserMessage>().ToListAsync();
        }

        public async Task<UserMessage> GetById(int id)
        {
            return await _context.Set<UserMessage>().FindAsync(id);
        }

        public async Task Update(UserMessage entity)
        {
            _context.Set<UserMessage>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(UserMessage entity)
        {
            _context.Set<UserMessage>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<UserMessage>> GetAllActive()
        {
            throw new NotImplementedException();
        }
    }

}
