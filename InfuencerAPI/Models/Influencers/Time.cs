using InfuencerAPI.Models.Master;

namespace InfuencerAPI.Models.Influencers
{
    public class Time
    {
        public Guid Id { get; set; }
        public Guid InfluencerId { get; set; }
        public Guid? TimeSettingId { get; set; }
        public DateTime DateCreated { get; set; }

        public Influencer Influencer { get; set; }
        public Settings TimeSetting { get; set; }
    }
}
