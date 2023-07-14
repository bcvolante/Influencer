namespace InfuencerAPI.Models.OrdersDTO
{
    public class UpdateCalendarRequest
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string Date { get; set; }
        public Guid? TimeId { get; set; }
    }
}
