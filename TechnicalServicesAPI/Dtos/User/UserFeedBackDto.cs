namespace TechnicalServicesAPI.Dtos.User
{
    public class UserFeedBackDto
    {
        public int OrderId { get; set; }
        [MaxLength(1000)]
        public string Message { get; set; }
    }
}
