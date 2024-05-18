using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using PayPal.Api;
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

        [HttpPost("create-paypal-transaction")]
        public IActionResult CreatePayPalTransaction(decimal amount)
        {
            amount = amount > 0 ? amount : 1.00m; // Set a default minimum amount
            var payment = _payPalService.CreatePayment(amount, "Donation to Rubber City Foundation", "http://localhost:4200/donate/success", "http://localhost:4200/donate/cancel");

            return Ok(new { approvalUrl = payment.GetApprovalUrl() });
        }

        [HttpGet("execute-paypal-transaction")]
        public async Task<IActionResult> ExecutePayPalTransaction(string paymentId, string PayerID)
        {
            var payment = await _payPalService.ExecutePayment(paymentId, PayerID);
            if (payment.state == "approved")
            {
                // Here you can save the donation details in your database
                return Ok(new { success = true });
            }
            return BadRequest(new { success = false });
        }
    }
}

public static class PaymentExtensions
{
    public static string GetApprovalUrl(this Payment payment)
    {
        var links = payment.links.GetEnumerator();
        while (links.MoveNext())
        {
            var link = links.Current;
            if (link.rel.ToLower().Trim().Equals("approval_url"))
            {
                return link.href;
            }
        }
        return null;
    }
}
