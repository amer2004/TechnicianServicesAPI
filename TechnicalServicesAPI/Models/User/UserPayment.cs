namespace TechnicalServicesAPI.Models.User
{
    public class UserPayment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
       // public User User { get; set; }
        public int PaymentTypeId { get; set; }
        public double PaymentAmount { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime DateTime { get; set; }
    }
}
