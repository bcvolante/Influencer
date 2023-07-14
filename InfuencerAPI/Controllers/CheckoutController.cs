using Microsoft.AspNetCore.Mvc;
//using Stripe;
using Stripe.Checkout;
using InfluencerAPI.Models.Stripe;
using InfluencerAPI.Models.OrdersDTO;
using InfuencerAPI.Models.Orders;
using InfuencerAPI.Models.OrdersDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Headers;
using static System.Net.WebRequestMethods;

namespace InfluencerAPI.Controllers;

[ApiController]
[Route("[controller]")]
//[ApiExplorerSettings(IgnoreApi = true)]
public class CheckoutController : ControllerBase
{
    private readonly IConfiguration _configuration;

    private static string s_wasmClientURL = "";

    public CheckoutController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<ActionResult> CheckoutOrder([FromBody] List<Product> product, [FromServices] IServiceProvider sp)
    {
        //var referer = Request.Headers.Referer;
        //var referer = Request.Headers.Referer.ToString();
        //s_wasmClientURL = Request.Headers.Referer.ToString();
        //s_wasmClientURL = referer[0];

        // Build the URL to which the customer will be redirected after paying.
        var server = sp.GetRequiredService<IServer>();

        var serverAddressesFeature = server.Features.Get<IServerAddressesFeature>();

        string? thisApiUrl = string.Empty;

        if (serverAddressesFeature is not null)
        {
            thisApiUrl = serverAddressesFeature.Addresses.FirstOrDefault();
        }

        if (thisApiUrl is not null)
        {
            var sessionId = await CheckOut(product, thisApiUrl);
            var pubKey = _configuration["Stripe:PubKey"];

            var checkoutOrderResponse = new CheckoutOrderResponse()
            {
                SessionId = sessionId,
                PubKey = pubKey
            };

            return Ok(checkoutOrderResponse);
        }
        else
        {
            return StatusCode(500);
        }
    }

    [NonAction]
    public async Task<string> CheckOut(List<Product> product, string thisApiUrl)
    {
        var _LineItems = new List<SessionLineItemOptions>();

        foreach (var item in product)
        {
            var _LineItem = new SessionLineItemOptions()
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = item.Price, // Price is in USD cents.
                    Currency = "USD",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = item.Title,
                        Description = item.Description,
                        Images = new List<string> { item.ImageUrl }
                    },
                },
                Quantity = 1,
            };
            _LineItems.Add(_LineItem);
        }


        // Create a payment flow from the items in the cart.
        // Gets sent to Stripe API.
        var options = new SessionCreateOptions
        {
            // Stripe calls the URLs below when certain checkout events happen such as success and failure.
            SuccessUrl = $"{thisApiUrl}/checkout/success?sessionId=" + "{CHECKOUT_SESSION_ID}", // Customer paid.
            //CancelUrl = $"{thisApiUrl}/checkout/success", // Customer paid.
            CancelUrl = "https://localhost:7247/failed", // Customer paid.
            //CancelUrl = s_wasmClientURL + "failed",  // Checkout cancelled.
            PaymentMethodTypes = new List<string> // Only card available in test mode?
            {
                "card"
            },
            LineItems = _LineItems,
            Mode = "payment" // One-time payment. Stripe supports recurring 'subscription' payments.
        };


        try
        {
            var service = new SessionService();
            var session = service.Create(options);
            await Task.Delay(1);
            return session.Id;
        }
        catch (Exception ex)
        {
            // Log or examine the exception details
            Console.WriteLine(ex.ToString());
            throw;
        }

    }

    [HttpGet("success")]
    // Automatic query parameter handling from ASP.NET.
    // Example URL: https://localhost:7051/checkout/success?sessionId=si_123123123123
    public ActionResult CheckoutSuccess(string sessionId)
    {
        var sessionService = new SessionService();
        var session = sessionService.Get(sessionId);

        // Here you can save order and customer details to your database.
        var total = 
            session.AmountTotal.Value;
        var customerEmail = session.CustomerDetails.Email;

        return Redirect("https://localhost:7247/success");
    }
}
