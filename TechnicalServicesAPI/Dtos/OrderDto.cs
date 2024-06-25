namespace TechnicalServicesAPI.Dtos
{
    public class OrderDto
    {
        public int UserId { get; set; }

        public int ExtendServiceId { get; set; }

        public double XLocation { get; set; }

        public double YLocation { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }
    }
}
