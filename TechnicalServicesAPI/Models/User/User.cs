using Microsoft.CodeAnalysis;
using System.Collections;

using System.Drawing;

namespace TechnicalServicesAPI.Models.User
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength (20)]
        public string LastName { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public double Balance { get; set; }

        public bool IsTechnician { get; set; }

        public DateTime SignUpDate { get; set; }

        public double XLocation { get; set; }

        public double YLocation { get; set; }
        
        public List<UserNotifcation> UserNotifcations { get; set; }
    }
}
