namespace TechnicalServicesAPI.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPaymentsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserPaymentsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetUserPayments/{id}"), Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> GetUserPayments(int id)
        {
            var Payments = await _context.UsersPayments.Include(p => p.PaymentType).Where(p => p.UserId == id).ToListAsync();
            return Ok(Payments);
        }

        [HttpPost("AddUserPaymnet"), Authorize(Roles = "User")]
        public async Task<IActionResult> AddUserPayment([FromBody] UserPaymentDto dto)
        {
            var User = await _context.Users.FindAsync(dto.UserId);
            if (User == null)
                return BadRequest($"there are no user eith id:{dto.UserId}");

            var isValedPaymentType = await _context.PaymentTypes.AnyAsync(p => p.Id == dto.PaymentTypeId);
            if (!isValedPaymentType)
                return BadRequest($"there are no Payment Type with id:{dto.PaymentTypeId}");

            if (User.Balance < dto.PaymentAmount)
                return BadRequest("you dont have enough Credit in your account");

            User.Balance -= dto.PaymentAmount;
            _context.Update(User);

            var UserPayment = new UserPayment
            {
                PaymentAmount = dto.PaymentAmount,
                DateTime = DateTime.Now,
                UserId = dto.UserId,
                PaymentTypeId = dto.PaymentTypeId,
            };

            _context.UsersPayments.Add(UserPayment);
            _context.SaveChanges();

            return Ok(UserPayment);
        }
    }
}
