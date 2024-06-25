namespace TechnicalServicesAPI.Dtos
{
    public class RatingTypeDto
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
