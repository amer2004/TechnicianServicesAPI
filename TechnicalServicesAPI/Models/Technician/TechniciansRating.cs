namespace TechnicalServicesAPI.Models.Technician
{
    public class TechniciansRating
    {
        public int Id { get; set; }
        public int RatingTypeId { get; set; }
        public RatingType RatingType { get; set; }
        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }
        public double Value { get; set; }
    }
}
