namespace TechnicalServicesAPI.Models.User
{
    public class UserNotifcation
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
       // public User User { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        //new notifcation = true
        public bool Status { get; set; }
    }
}
