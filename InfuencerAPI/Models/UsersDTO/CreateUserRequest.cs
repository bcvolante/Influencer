namespace InfuencerAPI.Models.UsersDTO
{
    public class CreateUserRequest
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
        public int Size { get; set; }
        public string Address { get; set; }
    }
}
