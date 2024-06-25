using TechnicalServicesAPI.Dtos.Technician;

namespace TechnicalServicesAPI.Controllers.Controller_Tec
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianRatingController : ControllerBase
    {
        private readonly ApplicationDBContext _Context;
        public TechnicianRatingController(ApplicationDBContext context)
        {
            _Context = context;
        }

        [HttpGet("GetAllRating"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTechnicianRatings()
        {
            var ratings = await _Context.TechniciansRatings.ToListAsync();
            return Ok(ratings);
        }

        [HttpGet("GetRatingByTechnicianId/{TechId}"), Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> GetRatingByid(int TechId)
        {
            var IsValerTechId = await _Context.Technicians.AnyAsync(T => T.Id == TechId);
            if (!IsValerTechId)
                return BadRequest($"there no Technicina With id:{TechId}");

            var TecRatings = await _Context.TechniciansRatings.Include(R=>R.RatingType).Where(R => R.TechnicianId == TechId).ToListAsync();
            if (TecRatings == null)
                return BadRequest($"there no Rationgs for these Technicina");

            return Ok(TecRatings);
        }

        [HttpPost("AddRating"),Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddRating(TechnicianRatingDto dto)
        {
            var IsValerTechId = await _Context.Technicians.AnyAsync(T => T.Id == dto.TechnicianId);
            if (!IsValerTechId)
                return BadRequest($"there no Technicina With id:{dto.TechnicianId}");

            var IsValerRating = await _Context.RatingTypes.AnyAsync(R => R.Id == dto.RatingTypeId);
            if (!IsValerTechId)
                return BadRequest($"there no Technicina With id:{dto.RatingTypeId}");

            var Rating = new TechniciansRating
            {
                RatingTypeId = dto.RatingTypeId,
                TechnicianId = dto.TechnicianId,
                Value = dto.Value
            };
            await _Context.AddAsync(Rating);
            _Context.SaveChanges();
            return Ok(Rating);
        }

        [HttpPut("UpdateRating/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateRating(int id,[FromBody]double value)
        {
            var rating = await _Context.TechniciansRatings.FindAsync(id);
            if (rating == null)
                return BadRequest($"Not found id=>{id}");

            rating.Value =value;

            _Context.Update(rating);
            _Context.SaveChanges();

            return Ok(rating);
        }

    }
}
