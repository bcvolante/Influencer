using InfuencerAPI.Models.Users;

namespace InfluencerAPI.Models.UsersDTO
{
    public class LoginViewResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EmailVerified { get; set; }
        public bool PasswordVerified { get; set; }
        public bool IsActive { get; set; }
        public string? RefreshToken { get; set; }
        public Guid? TypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string ImagePath { get; set; }
        public Guid? IndustryId { get; set; }
        public int Size { get; set; }

        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public object? Content { get; set; }
    }
}
