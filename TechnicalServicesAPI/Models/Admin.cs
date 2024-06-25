namespace TechnicalServicesAPI.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [MaxLength(30)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public int AccessLevel { get; set; }

        [MaxLength(11)]
        public string SocialSecurityNumber { get; set; }
        public List<Technician.Technician> ApprovedTechnicians { get; set; }
        public List<UserFeedBackResponse> UserFeedBackResponses { get; set; }
        public List<TechnicianFeedBackResponse> TechnicianFeedbackResponses { get; set; }

    }
}