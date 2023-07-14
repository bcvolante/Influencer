namespace InfuencerAPI.Models.Influencers
{
    public class RestDay
    {
        public Guid Id { get; set; }
        public Guid InfluencerId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public Guid TimeId { get; set; }
        public DateTime DateCreated { get; set; }

        public Influencer Influencer { get; set; }
    }
}
