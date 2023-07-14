namespace InfuencerAPI.Models.OrdersDTO
{
    public class CreateCalendarRequest
    {
        public Guid OrderId { get; set; }
        public string Date { get; set; }
        public Guid? TimeId { get; set; }
    }
}
