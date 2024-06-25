namespace TechnicalServicesAPI.Dtos
{
    public class PaymentTypeDto
    {
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
