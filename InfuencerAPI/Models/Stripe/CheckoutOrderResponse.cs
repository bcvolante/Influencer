namespace InfluencerAPI.Models.Stripe
{
    public class CheckoutOrderResponse
    {
        public string? SessionId { get; set; }
        public string? PubKey { get; set; }
    }
}
