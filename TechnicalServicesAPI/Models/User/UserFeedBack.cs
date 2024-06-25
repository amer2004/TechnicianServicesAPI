namespace TechnicalServicesAPI.Models.User
{
    public class UserFeedBack
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }
        public List<UserFeedBackRating> UserFeedBackRatings { get; set; }
    }
}
