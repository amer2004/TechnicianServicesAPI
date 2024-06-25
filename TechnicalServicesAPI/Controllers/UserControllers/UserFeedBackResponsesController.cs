using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalServicesAPI.Dtos.Technician;

namespace TechnicalServicesAPI.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFeedBackResponsesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserFeedBackResponsesController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetUserFeedBackResponse/{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserFeedBackResponseById(int id)
        {
            var UserFeedBackResponse = await _context.UserFeedBackResponses.SingleOrDefaultAsync(x => x.Id == id);
            if (UserFeedBackResponse == null)
                return BadRequest($"there no UserFeedBackResponses with id:{id}");

            return Ok(UserFeedBackResponse);
        }

        [HttpPost("AddFeedBackResponse"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddFeedBackResponse([FromBody] UserFeedBackResponseDto dto)
        {
            var UserFeedBackResponse = new UserFeedBackResponse()
            {
                Message = dto.Message,
            };

            await _context.AddAsync(UserFeedBackResponse);
            return Ok(UserFeedBackResponse);
        }
    }
}
