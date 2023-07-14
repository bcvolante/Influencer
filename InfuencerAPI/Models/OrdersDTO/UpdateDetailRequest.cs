namespace InfuencerAPI.Models.OrdersDTO
{
    public class UpdateDetailRequest
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid? TypeId { get; set; }
        public Guid? ServiceTypeId { get; set; }
        public double Amount { get; set; }
    }
}
