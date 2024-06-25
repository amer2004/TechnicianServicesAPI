using TechnicalServicesAPI.Models.User;

namespace TechnicalServicesAPI.Models
{
    public class PaymentType
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        public double Amount { get; set; }
        //public List<UserPayment> UserPayments { get; set; }
    }
}
