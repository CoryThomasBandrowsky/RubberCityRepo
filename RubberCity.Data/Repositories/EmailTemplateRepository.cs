using Domain.Models;
using Microsoft.EntityFrameworkCore;
using RubberCity.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RubberCity.Data.Repositories
{
    public class EmailTemplateRepository : IEmailTemplateRepository<EmailTemplate>
    {
        private readonly DbContext _context;

        public EmailTemplateRepository(DbContext context)
        {
            _context = context;
        }

        public async Task Add(EmailTemplate entity)
        {
            _context.Set<EmailTemplate>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmailTemplate>> GetAll()
        {
            return await _context.Set<EmailTemplate>().ToListAsync();
        }

        public async Task<EmailTemplate> GetById(int id)
        {
            return await _context.Set<EmailTemplate>().FindAsync(id);
        }

        public async Task Update(EmailTemplate entity)
        {
            _context.Set<EmailTemplate>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(EmailTemplate entity)
        {
            _context.Set<EmailTemplate>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
