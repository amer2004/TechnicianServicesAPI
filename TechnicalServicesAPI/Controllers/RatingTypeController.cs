namespace TechnicalServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingTypeController : ControllerBase
    {
        private readonly ApplicationDBContext _Context;
        public RatingTypeController(ApplicationDBContext context)
        {
            _Context = context;
        }

        [HttpGet("GetAllRatingTypes")]
        public async Task<IActionResult> GetRatingTypes()
        {
            var ratingTypes = await _Context.RatingTypes.ToListAsync();
            return Ok(ratingTypes);
        }

        [HttpGet("GetRatingTypeById/{id}")]
        public async Task<IActionResult> GetRatingTypeById(int id)
        {
            var ratingType = await _Context.RatingTypes.FindAsync(id);
            if (ratingType == null)
                return BadRequest($"there no rating Type With id:{id}");

            return Ok(ratingType);
        }

        [HttpPost("AddRatingType"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddTypeRating(RatingTypeDto dto)
        {
            var type = new RatingType
            {
                Name = dto.Name
            };

            await _Context.AddAsync(type);
            _Context.SaveChanges();
            return Ok(type);
        }
    }
}
