using System.ComponentModel.DataAnnotations;

namespace TechnicalServicesAPI.Models.Technician
{
    public class TechnicianStatus
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
        public List<Technician> Technicians { get; set; }
    }
}
