using InfuencerAPI.Models.Influencers;
using InfuencerAPI.Models.Users;

namespace InfuencerAPI.Models.Orders
{
    public class Orders
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? InfluencerId { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Remarks { get; set; }

        public Users.Users User { get; set; }
        public Influencer Influencer { get; set; }
    }
}
