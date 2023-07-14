using InfuencerAPI.Models.Master;

namespace InfuencerAPI.Models.Influencers
{
    public class Influencer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public Guid? NationalityId { get; set; }
        public Guid? IndustryId { get; set; }
        public Guid? GenderId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public Settings Nationality { get; set; }
        public Settings Industry { get; set; }
        public Settings Gender { get; set; }
    }
}
