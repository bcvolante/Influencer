using InfuencerAPI.Models.Master;

namespace InfuencerAPI.Models.Influencers
{
    public class Service
    {
        public Guid Id { get; set; }
        public Guid InfluencerId { get; set; }
        public Guid? TypeId { get; set; }
        public Guid? ServiceSettingId { get; set; }
        public double Amount { get; set; }
        public DateTime DateCreated { get; set; }

        public Influencer Influencer { get; set; }
        public Settings Type { get; set; }
        public Settings ServiceSetting { get; set; }
    }
}
