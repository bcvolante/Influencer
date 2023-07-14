using InfluencerAPI.Models.Stripe;
using InfuencerAPI.Data;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using InfluencerAPI.Models.OrdersDTO;
using InfuencerAPI.Models.MasterDTO;
using InfuencerAPI.Models.Orders;
using InfuencerAPI.Models.OrdersDTO;

namespace InfluencerAPI.Services
{
    public class CheckoutService: ICheckoutService
    {
        private readonly InfluencerDbContext dbContext;
        private static string s_wasmClientURL = string.Empty;

        public CheckoutService(InfluencerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
