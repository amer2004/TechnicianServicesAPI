namespace TechnicalServicesAPI.Dtos
{
    public class OrderStatusDto
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
    }
}
