namespace InfuencerAPI.Models.OrdersDTO
{
    public class CreateTargetRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
    }
}
