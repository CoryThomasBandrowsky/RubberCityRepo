using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using RubberCity.Services.Services;
using System.Threading.Tasks;

namespace RubberCityAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DonationsController : ControllerBase
    {
        private readonly DonationService _donationService;
        private readonly PayPalService _payPalService;

        public DonationsController(DonationService donationService, PayPalService payPalService)
        {
            _donationService = donationService;
            _payPalService = payPalService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllDonations()
        {
            var donations = await _donationService.GetAllDonations();
            return Ok(donations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonationById(int id)
        {
            var donation = await _donationService.GetDonationById(id);
            if (donation == null)
            {
                return NotFound();
            }
            return Ok(donation);
        }

        [HttpPost]
        public async Task<IActionResult> AddDonation([FromBody] Donation donation)
        {
            await _donationService.AddDonation(donation);
            return CreatedAtAction(nameof(GetDonationById), new { id = donation.ID }, donation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonation(int id, [FromBody] Donation donation)
        {
            if (id != donation.ID)
            {
                return BadRequest();
            }

            await _donationService.UpdateDonation(donation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonation(int id)
        {
            await _donationService.DeleteDonation(id);
            return NoContent();
        }

        [HttpPost("AddPayPalDonation")]
        public async Task<IActionResult> AddPayPalDonation([FromBody] Donation donation)
        {
            var payment = await _payPalService.GetPaymentDetails(donation.PaymentId);
            if (payment.state == "approved")
            {
                await _donationService.AddDonation(donation);
                return CreatedAtAction(nameof(GetDonationById), new { id = donation.ID }, donation);
            }
            return BadRequest("Payment not approved");
        }
    }
}
