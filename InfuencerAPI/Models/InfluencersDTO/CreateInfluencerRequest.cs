using InfuencerAPI.Models.Master;

namespace InfuencerAPI.Models.InfluencersDTO
{
    public class CreateInfluencerRequest
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public Guid? NationalityId { get; set; }
        public Guid? IndustryId { get; set; }
        public Guid? GenderId { get; set; }
    }
}
