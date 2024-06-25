namespace TechnicalServicesAPI.Models.Technician
{
    public class TechniciansServices
    {
        public int Id { get; set; }
        public int ExtendServiceId { get; set; }
        public ExtendService ExtendService { get; set; }
        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }
    }
}
