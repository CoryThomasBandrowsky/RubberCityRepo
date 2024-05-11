using Domain.Models;
using Microsoft.Extensions.Options;
using RubberCity.Data.Interfaces;  // Ensure your HelpRequestRepository implements IRepository<HelpRequestModel>
using System.Threading.Tasks;

namespace RubberCity.Services.Services
{
    public class HelpRequestService
    {
        private readonly IRepository<HelpRequestModel> _repo;
        private readonly AppSettings _appSettings;

        public HelpRequestService(IOptionsSnapshot<AppSettings> appSettings, IRepository<HelpRequestModel> repo)
        {
            _appSettings = appSettings.Value;
            _repo = repo;
        }

        public async Task<HelpRequestModel> GetByIdAsync(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<IEnumerable<HelpRequestModel>> GetAllAsync()
        {
            return await _repo.GetAll();
        }

        public async Task AddHelpRequestAsync(HelpRequestModel helpRequest)
        {
            await _repo.Add(helpRequest);
        }

        public async Task UpdateHelpRequestAsync(HelpRequestModel helpRequest)
        {
            await _repo.Update(helpRequest);
        }

        public async Task DeleteHelpRequestAsync(HelpRequestModel helpRequest)
        {
            await _repo.Delete(helpRequest);
        }
    }
}
