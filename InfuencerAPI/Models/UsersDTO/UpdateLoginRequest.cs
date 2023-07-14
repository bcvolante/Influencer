namespace InfuencerAPI.Models.UsersDTO
{
    public class UpdateLoginRequest
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
