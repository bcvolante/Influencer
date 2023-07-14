using InfuencerAPI.Models.Master;

namespace InfuencerAPI.Models.Orders
{
    public class Calendar
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string Date { get; set; }
        public Guid? TimeId { get; set; }
        public DateTime DateCreated { get; set; }

        public Orders Order { get; set; }
        public Settings Time { get; set; }
    }
}
