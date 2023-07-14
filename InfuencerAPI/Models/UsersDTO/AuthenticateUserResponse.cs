namespace InfluencerAPI.Models.UsersDTO
{
    public class AuthenticateUserResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
