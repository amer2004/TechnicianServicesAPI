using TechnicalServicesAPI.Dtos.User;

namespace TechnicalServicesAPI.Dtos.Technician
{
    public class TechnicianDto
    {
        public int UserId { get; set; }

        [MaxLength(30)]
        public string UserName { get; set; }

        public int AccountType { get; set; }

        [MaxLength(11)]
        public string SocialSecurityNumber { get; set; }

        //public UserDto User { get; set; }
    }
}
