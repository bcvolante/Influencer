namespace InfluencerAPI.Models.InfluencersDTO
{
    public class InfluencerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public Guid? NationalityId { get; set; }
        public string Nationality { get; set; }
        public Guid? IndustryId { get; set; }
        public string Industry { get; set; }
        public Guid? GenderId { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
