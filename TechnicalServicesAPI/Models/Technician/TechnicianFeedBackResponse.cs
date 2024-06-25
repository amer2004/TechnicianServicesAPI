namespace TechnicalServicesAPI.Models.Technician
{
    public class TechnicianFeedBackResponse
    {
        public int Id { get; set; }

        public int AdminId { get; set; }

        public Admin Admin { get; set; }

        public int TechnicianFeedBackId { get; set; }

        public TechnicianFeedBack TechnicianFeedBack { get; set; }
        
        [MaxLength(1000)]
        public string Message { get; set; }
    }
}
