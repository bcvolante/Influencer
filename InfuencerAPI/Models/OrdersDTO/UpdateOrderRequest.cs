namespace InfuencerAPI.Models.OrdersDTO
{
    public class UpdateOrderRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? InfluencerId { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
