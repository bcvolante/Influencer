namespace InfuencerAPI.Models.InfluencersDTO
{
    public class UpdateTimeRequest
    {
        public Guid Id { get; set; }
        public Guid InfluencerId { get; set; }
        public Guid? TimeSettingId { get; set; }
    }
}
