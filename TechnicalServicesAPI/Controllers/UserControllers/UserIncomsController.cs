namespace TechnicalServicesAPI.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserIncomsController : ControllerBase
    {
        private readonly ApplicationDBContext _Context;

        public UserIncomsController(ApplicationDBContext context)
        {
            _Context = context;
        }

        [HttpGet("GetUserIncoms/{id}"), Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetUserIncoms(int id)
        {
            var IsValedUser = await _Context.Users.AnyAsync(U => U.Id == id);
            if (!IsValedUser)
                return BadRequest($"there no user with the id:{id}");

            var incoms = await _Context.UsersIncoms.Where(i => i.UserId == id).ToListAsync();
            return Ok(incoms);
        }

        [HttpPost("AddUserIncom"),Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserIncom([FromBody] UserIncomeDto dto)
        {
            var User = await _Context.Users.FindAsync(dto.UserId);
            if (User == null)
                return BadRequest($"there no user with the id:{dto.UserId}");

            if (dto.amount <= 0)
                return BadRequest("the amount is not Valed!");

            var UserIncom = new UserIncom
            {
                UserId = dto.UserId,
                amount = dto.amount,
                DateTime = DateTime.Now,
            };

            _Context.UsersIncoms.Add(UserIncom);

            User.Balance += dto.amount;
            _Context.Update(User);

            _Context.SaveChanges();

            return Ok(UserIncom);
        }

    }
}
