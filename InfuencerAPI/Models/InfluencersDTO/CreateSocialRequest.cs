namespace InfuencerAPI.Models.InfluencersDTO
{
    public class CreateSocialRequest
    {
        public Guid InfluencerId { get; set; }
        public Guid? SocialMediaId { get; set; }
        public string Description { get; set; }
    }
}
