using Microsoft.AspNetCore.Authorization;
using TechnicalServicesAPI.Dtos.Technician;

namespace TechnicalServicesAPI.Controllers.TechnicianControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianFeedBackResponsesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TechnicianFeedBackResponsesController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetTechnicianFeedBackResponse/{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTechnicianFeedBackResponseById(int id)
        {
            var TechnicianFeedBackResponse = await _context.TechnicianFeedBackResponses.SingleOrDefaultAsync(x => x.Id == id);
            if (TechnicianFeedBackResponse == null)
                return BadRequest($"there no TechnicianFeedBackResponses with id:{id}");

            return Ok(TechnicianFeedBackResponse);
        }

        // to do get by feedback id

        [HttpPost("AddFeedBackResponse"), Authorize(Roles = "Admin")]
        public IActionResult AddFeedBackResponse([FromBody] TechnicianFeedBackResponseDto dto)
        {
            var TechnicianFeedBackResponse = new TechnicianFeedBackResponse()
            {
                Message = dto.Message,
            };

            _context.Add(TechnicianFeedBackResponse);
            _context.SaveChanges();

            return Ok(TechnicianFeedBackResponse);
        }
    }
}
