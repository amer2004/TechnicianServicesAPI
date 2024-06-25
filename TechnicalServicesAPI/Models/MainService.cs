namespace TechnicalServicesAPI.Models
{
    public class MainService
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public List<ExtendService> ExtendServices { get; set; }
    }
}