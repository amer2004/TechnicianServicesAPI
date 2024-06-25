namespace TechnicalServicesAPI.Models.User
{
    public class UserFeedBackResponse
    {
        public int Id { get; set; }

        public int AdminId { get; set; }

        public Admin Admin { get; set; }
        public int UserFeedBackId { get; set; }
        public UserFeedBack UserFeedBack { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }
    }
}