namespace TechnicalServicesAPI.Dtos.Technician
{
    public class TechnicianFeedBackResponseDto
    {
        public int AdminId { get; set; }

        public int TechnicianFeedBackId { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }
    }
}
