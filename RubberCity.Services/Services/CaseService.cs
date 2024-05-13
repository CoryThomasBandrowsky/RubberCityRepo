using Domain.Models;
using Microsoft.Extensions.Options;
using RubberCity.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubberCity.Services.Services
{
    public class CaseService
    {
        private readonly IRepository<Case> _repo;
        private readonly AppSettings _appSettings;

        public CaseService(IOptionsSnapshot<AppSettings> appSettings, IRepository<Case> repo)
        {
            _appSettings = appSettings.Value;
            _repo = repo;
        }

        public async Task<Case> GetByIdAsync(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<IEnumerable<Case>> GetAllAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<IEnumerable<Case>> GetAllActiveAsync()
        {
            return await _repo.GetAllActive();
        }

        public async Task AddCaseAsync(Case Case)
        {
            await _repo.Add(Case);
        }

        public async Task UpdateCaseAsync(Case Case)
        {
            await _repo.Update(Case);
        }

        public async Task DeleteCaseAsync(Case Case)
        {
            await _repo.Delete(Case);
        }
    }
}
