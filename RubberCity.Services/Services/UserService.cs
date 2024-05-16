using Domain.Models;
using Microsoft.Extensions.Options;
using RubberCity.Data.Interfaces;
using RubberCity.Data.Repositories;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RubberCity.Services.Services
{
    public class UserService
    {
        private readonly IUserRepository<User> _repo;
        private readonly AppSettings _appSettings;

        public UserService(IOptionsSnapshot<AppSettings> appSettings, IUserRepository<User> repo)
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
            CreatePasswordHash(user.InputPassword, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.InputPassword = null;

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

        public async Task<User> GetUserByEmail(string email)
        {
            return await _repo.GetUserByEmail(email);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
