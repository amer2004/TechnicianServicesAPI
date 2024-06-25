using Microsoft.AspNetCore.Authorization;

namespace TechnicalServicesAPI.Controllers.TechnicianControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianFeedBacksController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TechnicianFeedBacksController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetTechnicianFeedBack/{id}"), Authorize(Roles = "Admin,Tech")]
        public async Task<IActionResult> GetTechnicianFeedBackById(int id)
        {
            var TechnicianFeedBack = await _context.TechniciansFeedBack.SingleOrDefaultAsync(x => x.Id == id);
            if (TechnicianFeedBack == null)
                return BadRequest($"there no TechnicianFeedBack with id:{id}");
            return Ok(TechnicianFeedBack);
        }

        [HttpPost("AddTechnicianFeedBack"), Authorize(Roles = "Tech")]
        public async Task<IActionResult> AddFeedBack([FromBody]TechnicianFeedBack dto)
        {
            var isvalidOrder = await _context.Orders.AnyAsync(o => o.Id == dto.OrderId);
            if (!isvalidOrder)
                return BadRequest($"there no order with id:{dto.OrderId}");

            var TechnicianFeedBack = new TechnicianFeedBack()
            {
                OrderId= dto.OrderId,
                Message = dto.Message,
            };

            await _context.AddAsync(TechnicianFeedBack);
            _context.SaveChanges();

            return Ok(TechnicianFeedBack);
        }
    }
}
