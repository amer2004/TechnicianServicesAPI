namespace TechnicalServicesAPI.Models.User
{
    public class UserFeedBackRating
    {
        public int Id { get; set; }
        public int UserFeedBackId { get; set; }
        public UserFeedBack UserFeedBack { get; }
        public int RatingTypeId { get; set; }
        public RatingType RatingType { get; set; }
        public double Value { get; set; }
    }
}