namespace InfuencerAPI.Models.Users
{
    public class Login
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserId { get; set; }
        public bool EmailVerified { get; set; }
        public bool PasswordVerified { get; set; }
        public bool IsActive { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime DateCreated { get; set; }

        public Users User { get; set; }
    }
}