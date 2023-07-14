namespace InfuencerAPI.Models.InfluencersDTO
{
    public class UpdateServiceRequest
    {
        public Guid Id { get; set; }
        public Guid InfluencerId { get; set; }
        public Guid? TypeId { get; set; }
        public Guid? ServiceSettingId { get; set; }
        public double Amount { get; set; }
    }
}
