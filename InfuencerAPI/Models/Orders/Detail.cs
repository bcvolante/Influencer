using InfuencerAPI.Models.Master;

namespace InfuencerAPI.Models.Orders
{
    public class Detail
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid? TypeId { get; set; }
        public Guid? ServiceTypeId { get; set; }
        public double Amount { get; set; }
        public DateTime DateCreated { get; set; }

        public Orders Order { get; set; }
        public Settings Type { get; set; }
        public Settings ServiceType { get; set; }
    }
}
