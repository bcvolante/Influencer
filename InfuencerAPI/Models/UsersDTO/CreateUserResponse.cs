namespace InfluencerAPI.Models.UsersDTO
{
    public class CreateUserResponse
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserId { get; set; }
    }
}
