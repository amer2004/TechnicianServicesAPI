namespace TechnicalServicesAPI.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNotifcationsController : ControllerBase
    {
        private readonly ApplicationDBContext _Context;

        public UserNotifcationsController(ApplicationDBContext context)
        {
            _Context = context;
        }

        [HttpGet("GetUserNotifcation/{id}"), Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserNotifcations(int id)
        {
            var isValedUser = await _Context.Users.AnyAsync(u => u.Id == id);
            if (!isValedUser)
                return BadRequest($"There no user with the id:{id}");

            var notfactions = await _Context.UsersNotifcations.Where(n => n.UserId == id).ToListAsync();
            return Ok(notfactions);
        }

        [HttpGet("GetNewUserNotifcation/{id}"), Authorize(Roles = "User")]
        public async Task<IActionResult> GetNewUserNotifcations(int id)
        {
            var isValedUser = await _Context.Users.AnyAsync(u => u.Id == id);
            if (!isValedUser)
                return BadRequest($"There no user with the id:{id}");

            var notfactions = await _Context.UsersNotifcations.Where(n => n.UserId == id && n.Status).ToListAsync();
            return Ok(notfactions);
        }

        [HttpPost("AddUserNotifcation"), Authorize]
        public async Task<IActionResult> AddUserNotifcation([FromBody] UserNotifcationDto dto)
        {
            var isValedUser = await _Context.Users.AnyAsync(u => u.Id == dto.UserId);
            if (!isValedUser)
                return BadRequest($"There no user with the id:{dto.UserId}");

            var notifcation = new UserNotifcation
            {
                Title = dto.Title,
                Message = dto.Message,
                UserId = dto.UserId,
                DateTime = DateTime.Now,
                Status = true,
            };

            _Context.UsersNotifcations.Add(notifcation);
            _Context.SaveChanges();
            return Ok(notifcation);
        }

        [HttpPost("AddNewOrderNotifcations"), Authorize(Roles = "User")]
        public async Task<IActionResult> AddNewOrderNotifcations([FromBody]int OrderExtendServiceId)
        {

            var tech = await _Context.TechniciansServices
                .Where(s => s.ExtendServiceId == OrderExtendServiceId).ToListAsync();

            var techs = new List<Technician>();
            foreach (var item in tech)
            {
                var tec = await _Context.Technicians.FirstOrDefaultAsync(T => T.Id == item.TechnicianId);
                techs.Add(tec);
            }

            var notifcations = new List<UserNotifcation>();
            foreach (var item in techs)
            {
                var notifcation = new UserNotifcation
                {
                    Title = "there are new order",
                    Message = "there are a new odrer that you can respone to, be fast so you can be the first to send aresponse to encrease your chanse of being ex",
                    UserId = item.UserId,
                    DateTime = DateTime.Now,
                    Status = true,
                };
                _Context.UsersNotifcations.Add(notifcation);
                notifcations.Add(notifcation);
            }

            _Context.SaveChanges();
            return Ok(notifcations);
        }

        [HttpPut("MarkAsRead"), Authorize(Roles = "User")]
        public async Task<IActionResult> MarkAsRead([FromBody]int id)
        {
            var notification = await _Context.UsersNotifcations.FindAsync(id);
            if (notification == null)
                return BadRequest($"there no notification this id:{id}");

            if (!notification.Status)
                return BadRequest();

            notification.Status = false;

            _Context.Update(notification);
            await _Context.SaveChangesAsync();

            return Ok(notification);
        }
    }
}
