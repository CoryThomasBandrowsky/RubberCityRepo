using Domain.Models;
using Microsoft.Extensions.Options;
using PayPal.Api;
using System.Collections.Generic;

public class PayPalService
{
    private readonly APIContext _apiContext;

    public PayPalService()
    {

        var clientId = AppServiceStatic.GetSetting("PayPal.ClientId");
        var clientSecret = AppServiceStatic.GetSetting("PayPal.ClientSecret");
        var mode = AppServiceStatic.GetSetting("PayPal.Mode");

        var config = new Dictionary<string, string>
        {
            { "clientId", clientId },
            { "clientSecret", clientSecret },
            { "mode", mode }
        };

        var accessToken = new OAuthTokenCredential(clientId, clientSecret, config).GetAccessToken();
        _apiContext = new APIContext(accessToken) { Config = config };
    }

    public Payment CreatePayment(decimal amount, string description, string returnUrl, string cancelUrl)
    {
        var payment = new Payment
        {
            intent = "sale",
            payer = new Payer { payment_method = "paypal" },
            transactions = new List<Transaction>
            {
                new Transaction
                {
                    description = description,
                    amount = new Amount
                    {
                        currency = "USD",
                        total = amount.ToString("F2") // PayPal expects a string formatted to 2 decimal places
                    }
                }
            },
            redirect_urls = new RedirectUrls
            {
                return_url = returnUrl,
                cancel_url = cancelUrl
            }
        };

        return payment.Create(_apiContext);
    }

    public async Task<Payment> ExecutePayment(string paymentId, string payerId)
    {
        var paymentExecution = new PaymentExecution { payer_id = payerId };
        var payment = new Payment { id = paymentId };

        return await Task.Run(() => payment.Execute(_apiContext, paymentExecution));
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
