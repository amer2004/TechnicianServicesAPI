namespace TechnicalServicesAPI.Models
{
    public class Response
    {
        public int Id { get; set; }

        public int TechnicianId { get; set; }

        public Technician.Technician Technician { get; set; }

        public int OrderId { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }

        public double EstimatedTime { get; set; }

        public double EstimatedPrice { get; set; }

    }
}
