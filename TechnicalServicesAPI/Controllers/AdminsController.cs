using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TechnicalServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private ApplicationDBContext _context;
        private IConfiguration _configuration;

        public AdminsController(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("GetAllAdmins"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAdmins()
        {
            var Admins = await _context.Admins.ToListAsync();
            return Ok(Admins);
        }

        [HttpGet("GetAdmin/{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var Admin = await _context.Admins.SingleOrDefaultAsync(x => x.Id == id);
            if (Admin == null)
                return BadRequest($"there no Admin with id:{id}");

            return Ok(Admin);
        }

        [HttpGet("LogeInCheack/{email}/{password}")]
        public async Task<IActionResult> LogeInCheack(string email, string password)
        {
            var Admin = await _context.Admins.Where(p => p.Email == email && p.Password == password).SingleOrDefaultAsync();
            if (Admin == null)
                return BadRequest("the email or password is not Coreact");

            var token = CreateToken(Admin);

            return Ok(token);
        }

        [HttpPost("AddAdmin"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAdmin([FromBody] AdminDto dto)
        {
            var isvaledEmail = await _context.Admins.AnyAsync(p => p.Email == dto.Email);
            if (isvaledEmail)
                return BadRequest("the email is alredy in use");

            var isvaledPhoneNumber = await _context.Admins.AnyAsync(p => p.PhoneNumber == dto.PhoneNumber);
            if (isvaledPhoneNumber)
                return BadRequest("the phone number is alredy in use");

            var Admin = new Admin
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber,
                AccessLevel = dto.AccessLevel,
                UserName = dto.UserName,
                SocialSecurityNumber = dto.SocialSecurityNumber,
            };

            await _context.AddAsync(Admin);
            _context.SaveChanges();

            return Ok(Admin);
        }

        [HttpPut("UpdateAdmin/{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAdmin(int id, [FromBody] AdminDto dto)
        {
            var Admin = await _context.Admins.SingleOrDefaultAsync(p => p.Id == id);
            if (Admin == null)
                return BadRequest($"there no Admin with id:{id}");

            Admin.FirstName = dto.FirstName;
            Admin.LastName = dto.LastName;
            Admin.PhoneNumber = dto.PhoneNumber;

            _context.Update(Admin);
            _context.SaveChanges();
            return Ok(Admin);
        }

        [HttpPut("UpdateAdminPassword/{Email}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangePassword(string Email, string newpassword)
        {
            var Admin = await _context.Admins.SingleOrDefaultAsync(p => p.Email == Email);
            if (Admin == null)
                return BadRequest($"there no Admin with Email:{Email}");

            if (Admin.Password == newpassword)
                return BadRequest("the password is alredy in use");

            Admin.Password = newpassword;

            _context.Update(Admin);
            _context.SaveChanges();
            return Ok(Admin);
        }

        private string CreateToken(Admin admin)
        {
            List<Claim> Claims;

            Claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,admin.Id.ToString()),
                new Claim (ClaimTypes.Email,admin.Email),
                new Claim(ClaimTypes.MobilePhone,admin.PhoneNumber),
                new Claim(ClaimTypes.Name,admin.UserName),
                new Claim(ClaimTypes.Actor,admin.AccessLevel.ToString()),
                new Claim(ClaimTypes.Role,"Admin"),
                };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:SecurityKey").Value!));

            var card = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);

            var Token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: card
                );

            var Jwt = new JwtSecurityTokenHandler().WriteToken(Token);

            return Jwt;
        }
    }
}
