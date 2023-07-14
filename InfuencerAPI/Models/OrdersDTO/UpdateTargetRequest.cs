namespace InfuencerAPI.Models.OrdersDTO
{
    public class UpdateTargetRequest
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
    }
}
