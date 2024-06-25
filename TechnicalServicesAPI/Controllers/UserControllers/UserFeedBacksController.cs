using TechnicalServicesAPI.Dtos.Technician;

namespace TechnicalServicesAPI.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFeedBacksController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserFeedBacksController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetUserFeedBack/{id}"), Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetUserFeedBackById(int id)
        {
            var UserFeedBack = await _context.UsersFeedBack.SingleOrDefaultAsync(x => x.Id == id);
            if (UserFeedBack == null)
                return BadRequest($"there no TechnicianFeedBack with id:{id}");

            return Ok(UserFeedBack);
        }

        [HttpPost("AddFeedBack"), Authorize(Roles = "User")]
        public async Task<IActionResult> AddFeeddBack([FromBody] TechnicianFeedBackDto dto)
        {

            var isvalidOrder = await _context.Orders.AnyAsync(o=>o.Id==dto.OrderId);
            if (!isvalidOrder)
                return BadRequest($"there no order with id:{dto.OrderId}");

            var UserFeedBack = new UserFeedBack()
            {
                OrderId=dto.OrderId,
                Message = dto.Message,
            };

            await _context.AddAsync(UserFeedBack);
            _context.SaveChanges();
            return Ok(UserFeedBack);
        }
    }
}
