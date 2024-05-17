using Domain.Models;
using RubberCity.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RubberCity.Services.Services
{
    public class DonationService
    {
        private readonly IDonationRepository<Donation> _donationRepository;

        public DonationService(IDonationRepository<Donation> donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<IEnumerable<Donation>> GetAllDonations()
        {
            return await _donationRepository.GetAll();
        }

        public async Task<Donation> GetDonationById(int id)
        {
            return await _donationRepository.GetById(id);
        }

        public async Task AddDonation(Donation donation)
        {
            await _donationRepository.Add(donation);
        }

        public async Task UpdateDonation(Donation donation)
        {
            await _donationRepository.Update(donation);
        }

        public async Task DeleteDonation(int id)
        {
            var donation = await _donationRepository.GetById(id);
            if (donation != null)
            {
                await _donationRepository.Delete(donation);
            }
        }
    }
}
