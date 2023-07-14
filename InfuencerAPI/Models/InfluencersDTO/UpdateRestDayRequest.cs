namespace InfuencerAPI.Models.InfluencersDTO
{
    public class UpdateRestDayRequest
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Time { get; set; }
    }
}
