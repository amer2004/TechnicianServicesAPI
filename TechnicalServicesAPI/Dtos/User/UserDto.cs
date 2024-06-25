namespace TechnicalServicesAPI.Dtos.User
{
    public class UserDto
    {
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public bool IsTechnician { get; set; }

        public double XLocation { get; set; }

        public double YLocation { get; set; }
    }
}
