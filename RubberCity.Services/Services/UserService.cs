using Domain.Models;
using Microsoft.Extensions.Options;
using RubberCity.Data.Interfaces; // Make sure your UserRepository implements IRepository<User>
using System.Threading.Tasks;

namespace RubberCity.Services.Services
{
    public class UserService
    {
        private readonly IRepository<User> _repo;
        private readonly AppSettings _appSettings;

        public UserService(IOptionsSnapshot<AppSettings> appSettings, IRepository<User> repo)
        {
            _appSettings = appSettings.Value;
            _repo = repo;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repo.GetAll();
        }

        public async Task AddUserAsync(User user)
        {
            await _repo.Add(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _repo.Update(user);
        }

        public async Task DeleteUserAsync(User user)
        {
            await _repo.Delete(user);
        }
    }
}
