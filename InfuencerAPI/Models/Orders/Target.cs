using InfuencerAPI.Models.Master;

namespace InfuencerAPI.Models.Orders
{
    public class Target
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public Orders Order { get; set; }
    }
}
