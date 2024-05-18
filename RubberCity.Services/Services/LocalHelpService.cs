using Domain.Models;
using RubberCity.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RubberCity.Services.Services
{
    public class LocalHelpService
    {
        private readonly ILocalHelpRepository<LocalHelp> _localHelpRepository;

        public LocalHelpService(ILocalHelpRepository<LocalHelp> localHelpRepository)
        {
            _localHelpRepository = localHelpRepository;
        }

        public async Task<IEnumerable<LocalHelp>> GetAllLocalHelp()
        {
            return await _localHelpRepository.GetAll();
        }

        public async Task<LocalHelp> GetLocalHelpById(int id)
        {
            return await _localHelpRepository.GetById(id);
        }

        public async Task AddLocalHelp(LocalHelp localHelp)
        {
            await _localHelpRepository.Add(localHelp);
        }

        public async Task UpdateLocalHelp(LocalHelp localHelp)
        {
            await _localHelpRepository.Update(localHelp);
        }

        public async Task DeleteLocalHelp(int id)
        {
            var localHelp = await _localHelpRepository.GetById(id);
            if (localHelp != null)
            {
                await _localHelpRepository.Delete(localHelp);
            }
        }
    }
}
