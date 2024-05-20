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
    public class UserMessageService
    {
        private readonly IRepository<UserMessage> _repo;

        public UserMessageService(IRepository<UserMessage> repo)
        {
            _repo = repo;
        }

        public async Task<UserMessage> GetByIdAsync(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<IEnumerable<UserMessage>> GetAllAsync()
        {
            return await _repo.GetAll();
        }

        public async Task AddUserMessageAsync(UserMessage UserMessage)
        {
            await _repo.Add(UserMessage);
        }

        public async Task UpdateUserMessageAsync(UserMessage UserMessage)
        {
            await _repo.Update(UserMessage);
        }

        public async Task DeleteUserMessageAsync(UserMessage UserMessage)
        {
            await _repo.Delete(UserMessage);
        }
    }
}
