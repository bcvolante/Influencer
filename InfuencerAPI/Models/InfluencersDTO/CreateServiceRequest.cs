namespace InfuencerAPI.Models.InfluencersDTO
{
    public class CreateServiceRequest
    {
        public Guid InfluencerId { get; set; }
        public Guid? TypeId { get; set; }
        public string Type { get; set; }
        public Guid? ServiceSettingId { get; set; }
        public string ServiceSetting { get; set; }
        public double Amount { get; set; }
    }
}
