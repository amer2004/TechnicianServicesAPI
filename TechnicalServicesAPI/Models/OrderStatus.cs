using System.ComponentModel.DataAnnotations;

namespace TechnicalServicesAPI.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
    }
}
