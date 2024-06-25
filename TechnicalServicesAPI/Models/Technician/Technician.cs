namespace TechnicalServicesAPI.Models.Technician
{
    public class Technician
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User.User User { get; set; }

        [MaxLength(30)]
        public string UserName { get; set; }

        public DateOnly LastSigninDate { get; set; }

        public int AccountType { get; set; }

        public int ExperienceLevel { get; set; }

        [MaxLength(11)]
        public string SocialSecurityNumber { get; set; }

        public int statusId { get; set; }
        public TechnicianStatus Status { get; set; }

        public int? ApprovedById { get; set; }
        public Admin? ApprovedBy { get; set; }

        public List<TechniciansRating>Ratings { get; set; }
    }
}