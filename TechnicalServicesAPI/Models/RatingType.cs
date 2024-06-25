using System.ComponentModel.DataAnnotations;
using TechnicalServicesAPI.Models.Technician;
using TechnicalServicesAPI.Models.User;

namespace TechnicalServicesAPI.Models
{
    public class RatingType
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

    }
}
