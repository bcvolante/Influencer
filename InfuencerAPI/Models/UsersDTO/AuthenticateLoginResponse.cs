namespace InfluencerAPI.Models.UsersDTO
{
    public class AuthenticateLoginResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? TypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Number { get; set; }
        public Guid? IndustryId { get; set; }
        public bool EmailVerified { get; set; }
        public bool PasswordVerified { get; set; }
        public bool IsActive { get; set; }
        public int Size { get; set; }
    }
}
