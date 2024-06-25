namespace TechnicalServicesAPI.Dtos
{
    public class ExtendServiceDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public int MainServiceId { get; set; }
    }
}
