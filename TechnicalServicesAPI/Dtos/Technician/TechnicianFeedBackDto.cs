namespace TechnicalServicesAPI.Dtos.Technician
{
    public class TechnicianFeedBackDto
    {
        public int OrderId { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }
    }
}
