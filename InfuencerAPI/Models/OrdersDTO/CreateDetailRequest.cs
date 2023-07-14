namespace InfuencerAPI.Models.OrdersDTO
{
    public class CreateDetailRequest
    {
        public Guid Id { get; set; }
        public Guid? TypeId { get; set; }
        public Guid? ServiceTypeId { get; set; }
        public double Amount { get; set; }
    }
}
