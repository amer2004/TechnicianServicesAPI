namespace TechnicalServicesAPI.Models
{
    public class ExtendService
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public int MainServiceId { get; set; }
        public MainService MainService{ get; set; }
    }
}