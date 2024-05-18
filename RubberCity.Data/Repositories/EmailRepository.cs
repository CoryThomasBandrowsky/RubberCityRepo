using Domain.Models;
using Microsoft.EntityFrameworkCore;
using RubberCity.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RubberCity.Data.Repositories
{
    public class EmailRepository : IEmailRepository<EmailLog>
    {
        private readonly DbContext _context;

        public EmailRepository(DbContext context)
        {
            _context = context;
        }

        public async Task Add(EmailLog entity)
        {
            _context.Set<EmailLog>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmailLog>> GetAll()
        {
            return await _context.Set<EmailLog>().ToListAsync();
        }

        public async Task<EmailLog> GetById(int id)
        {
            return await _context.Set<EmailLog>().FindAsync(id);
        }
    }
}
