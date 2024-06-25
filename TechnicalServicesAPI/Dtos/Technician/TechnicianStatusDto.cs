namespace TechnicalServicesAPI.Dtos.Technician
{
    public class TechnicianStatusDto
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
    }       
}
