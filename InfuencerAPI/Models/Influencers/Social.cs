using InfuencerAPI.Models.Master;

namespace InfuencerAPI.Models.Influencers
{
    public class Social
    {
        public Guid Id { get; set; }
        public Guid InfluencerId { get; set; }
        public Guid? SocialMediaId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public Influencer Influencer { get; set; }
        public Settings SocialMedia { get; set; }
    }
}
