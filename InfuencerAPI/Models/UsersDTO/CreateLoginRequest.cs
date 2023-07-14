namespace InfuencerAPI.Models.UsersDTO
{
    public class CreateLoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserId { get; set; }
    }
}
