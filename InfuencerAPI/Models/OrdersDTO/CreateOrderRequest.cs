namespace InfuencerAPI.Models.OrdersDTO
{
    public class CreateOrderRequest
    {
        public Guid UserId { get; set; }
        public Guid? InfluencerId { get; set; }
        public string Date { get; set; }
        public Guid? TimeId { get; set; }

    }
}
