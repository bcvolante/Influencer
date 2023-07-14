namespace InfuencerAPI.Models.InfluencersDTO
{
    public class CreateRestDayRequest
    {
        public Guid InfluencerId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public Guid TimeId { get; set; }
    }
}
