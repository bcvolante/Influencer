namespace InfuencerAPI.Models.InfluencersDTO
{
    public class UpdateSocialRequest
    {
        public Guid Id { get; set; }
        public Guid InfluencerId { get; set; }
        public Guid? SocialMediaId { get; set; }
        public string Description { get; set; }
    }
}
