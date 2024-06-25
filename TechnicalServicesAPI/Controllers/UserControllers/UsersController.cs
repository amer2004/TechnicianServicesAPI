using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TechnicalServicesAPI.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        Random _random;
        IEmailSender _Sender;
        IConfiguration _configuration;

        public UsersController(ApplicationDBContext context, IEmailSender emailSender, IConfiguration configuration)
        {
            _context = context;
            _random = new Random();
            _Sender = emailSender;
            _configuration = configuration;
        }

        [HttpGet("GetAllUsers"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("GetUser/{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return BadRequest($"there no user with id:{id}");
            return Ok(user);
        }

        [HttpGet("GetAllTechnicians"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTechnicians()
        {
            var technicians = await _context.Users.Where(p => p.IsTechnician == true).ToListAsync();
            return Ok(technicians);
        }

        [HttpGet("LogeIn/{email}/{passwrord}")]
        public async Task<IActionResult> LogeIn(string email, string passwrord)
        {
            var user = await _context.Users.Where(p => p.Email == email && p.Password == passwrord).SingleOrDefaultAsync();
            if (user == null)
                return BadRequest("the email or password is not Coreact");

            var Tech = await _context.Technicians.FirstOrDefaultAsync(T => T.UserId == user.Id);
            if (Tech is not null)
            {
                Tech.LastSigninDate = DateOnly.FromDateTime(DateTime.Now);
                _context.Update(Tech);
                await _context.SaveChangesAsync();
            }

            var token = CreateToken(user);

            return Ok(token);
        }

        [HttpGet("LogeInCheack/{email}/{passwrord}")]
        public async Task<IActionResult> LogeInCheack(string email, string passwrord)
        {
            var user = await _context.Users.Include(u => u.UserNotifcations).Where(p => p.Email == email && p.Password == passwrord).SingleOrDefaultAsync();
            if (user == null)
                return BadRequest("the email or password is not Coreact");

            var Tech = await _context.Technicians.FirstOrDefaultAsync(T => T.UserId == user.Id);
            if (Tech is not null)
            {
                Tech.LastSigninDate = DateOnly.FromDateTime(DateTime.Now);
                _context.Update(Tech);
                await _context.SaveChangesAsync();
            }

            return Ok(user);
        }

        [HttpGet("GetIsAllowedToOrder/{UserId}"), Authorize(Roles = "User")]
        public async Task<IActionResult> GetIsAllowedToOrder(int UserId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(p => p.Id == UserId);
            if (user == null)
                return BadRequest($"there no user with id:{UserId}");

            var orders = await _context.Orders.Where(o => o.UserId == UserId && o.StatusId == 3).ToListAsync();

            var payment = await _context.PaymentTypes.FirstOrDefaultAsync(p=>p.Id==2);

            var cashe =  user.Balance - (orders.Count * payment.Amount);
            if (cashe > payment.Amount * 2)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("SendVerificationCode/{Email}")]
        public async Task<IActionResult> SendVerificationcode(string Email)
        {
            try
            {
                int code = _random.Next(100000, 999999);
                await _Sender.SendEmailAsync(Email, "Actiovasen code", code.ToString());
                return Ok(code);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("GetIsUniqueEmail/{Email}")]
        public async Task<IActionResult> IsUniqueEmail(string Email)
        {
            var isvaledEmail = await _context.Users.AnyAsync(p => p.Email == Email);
            if (isvaledEmail)
                return Ok(false);

            return Ok(true);
        }

        [HttpGet("GetIsUniquePhoneNumber/{PhoneNumber}")]
        public async Task<IActionResult> IsUniquePhone(string PhoneNumber)
        {
            var isvaledPhoneNumber = await _context.Users.AnyAsync(p => p.PhoneNumber == PhoneNumber);
            if (isvaledPhoneNumber)
                return Ok(false);

            return Ok(true);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserDto dto)
        {
            var isvaledEmail = await _context.Users.AnyAsync(p => p.Email == dto.Email);
            if (isvaledEmail)
                return BadRequest("the email is alredy in use");

            var isvaledPhoneNumber = await _context.Users.AnyAsync(p => p.PhoneNumber == dto.PhoneNumber);
            if (isvaledPhoneNumber)
                return BadRequest("the phonenumber is alredy in use");

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber,
                XLocation = dto.XLocation,
                YLocation = dto.YLocation,
                Balance = 0,
                IsActive = true,
                IsTechnician = dto.IsTechnician,
            };

            await _context.AddAsync(user);
            _context.SaveChanges();
            return Ok(user);

        }

        [HttpPut("UpdateUser/{id}"), Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto dto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(p => p.Id == id);
            if (user == null)
                return BadRequest($"there no user with id:{id}");

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.XLocation = dto.XLocation;
            user.YLocation = dto.YLocation;
            user.IsActive = dto.IsActive;
            user.IsTechnician = dto.IsTechnician;

            _context.Update(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPut("UpdateUserPassword/{Email}")]
        public async Task<IActionResult> ChangePassword(string Email, [FromBody] string newpassword)
        {
            var user = await _context.Users.SingleOrDefaultAsync(p => p.Email == Email);
            if (user == null)
                return BadRequest($"there no user with id:{Email}");

            if (user.Password == newpassword)
                return BadRequest("the password is alredy in use");

            user.Password = newpassword;

            _context.Users.Update(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPut("DisableUser"), Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DisableUser([FromBody] int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(p => p.Id == id);
            if (user == null)
                return BadRequest($"there no user with id:{id}");
            user.IsActive = false;

            _context.Update(user);
            _context.SaveChanges();

            return Ok(user);
        }

        private string CreateToken(User user)
        {
            List<Claim> Claims;
            if (user.IsTechnician)
            {
                Claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim (ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
                new Claim(ClaimTypes.Actor,user.IsTechnician.ToString()),
                new Claim(ClaimTypes.Role,"User"),
                new Claim(ClaimTypes.Role,"Tech")
                };
            }
            else
            {
                Claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim (ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
                new Claim(ClaimTypes.Actor,user.IsTechnician.ToString()),
                new Claim(ClaimTypes.Role,"User"),
                };
            }

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:SecurityKey").Value!));

            var card = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);

            var Token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddDays(120),
                signingCredentials: card
                );

            var Jwt = new JwtSecurityTokenHandler().WriteToken(Token);

            return Jwt;
        }

    }
}
