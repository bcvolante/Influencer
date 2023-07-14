namespace InfuencerAPI.Models.InfluencersDTO
{
    public class CreateTimeRequest
    {
        public Guid InfluencerId { get; set; }
        public Guid? TimeSettingId { get; set; }
    }
}