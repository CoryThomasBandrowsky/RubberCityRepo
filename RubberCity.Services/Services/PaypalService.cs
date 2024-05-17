using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayPal.Api;
using System.Threading.Tasks;

namespace RubberCity.Services.Services
{
    public class PayPalService
    {
        private readonly APIContext _apiContext;

        public PayPalService()
        {
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            _apiContext = new APIContext(accessToken);
        }

        public async Task<Payment> GetPaymentDetails(string paymentId)
        {
            var payment = Payment.Get(_apiContext, paymentId);
            return payment;
        }
    }
}
