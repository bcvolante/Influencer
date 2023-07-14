namespace InfuencerAPI.Models.MasterDTO
{
    public class CreateSettingsRequest
    {
        public Guid TypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
