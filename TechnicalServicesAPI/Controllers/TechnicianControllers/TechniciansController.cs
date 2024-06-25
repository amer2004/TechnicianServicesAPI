namespace TechnicalServicesAPI.Controllers.TechnicianControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechniciansController : ControllerBase
    {
        private readonly ApplicationDBContext _Context;
        public TechniciansController(ApplicationDBContext Context)
        {
            _Context = Context;
        }

        [HttpGet("GetAllTechnicians")/*, Authorize(Roles = "Admin")*/]
        public async Task<IActionResult> GetAllAsync()
        {
            var technicion = await _Context.Technicians.ToListAsync();
            return Ok(technicion);
        }

        [HttpGet("GetTechnicianById/{id}"), Authorize]
        public async Task<IActionResult> GetTecById(int id)
        {
            var Tec = await _Context.Technicians.Include(t => t.User).SingleOrDefaultAsync(x => x.Id == id);
            if (Tec == null)
                return BadRequest($"there no Technician with id:{id}");

            return Ok(Tec);
        }

        [HttpGet("GetByUserName/{Username}"), Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetByUsername(string Username)
        {
            var Tec = await _Context.Technicians.SingleOrDefaultAsync(x => x.UserName == Username);
            if (Tec == null)
                return BadRequest($"there no Technician with this username:{Username}");

            return Ok(Tec);
        }

        [HttpGet("GetByUserId/{UserId}"), Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetByUsername(int UserId)
        {
            var Tec = await _Context.Technicians.SingleOrDefaultAsync(x => x.UserId == UserId);
            if (Tec == null)
                return BadRequest($"there no Technician with this user id:{UserId}");

            return Ok(Tec);
        }

        [HttpGet("GetIsUniqueUserName/{UserName}")]
        public async Task<IActionResult> IsUniqueUserName(string UserName)
        {
            var isvaledUserName = await _Context.Technicians.AnyAsync(p => p.UserName == UserName);
            if (isvaledUserName)
                return Ok(false);

            return Ok(true);
        }
        [HttpGet("GetIsUniqueSSN/{SSN}")]
        public async Task<IActionResult> IsUniqueSSN(string SSN)
        {
            var isvaledSSN = await _Context.Technicians.AnyAsync(p => p.SocialSecurityNumber == SSN);
            if (isvaledSSN)
                return Ok(false);

            return Ok(true);
        }

        [HttpPost("AddTechnician")]
        public async Task<IActionResult> AddTechnician([FromBody] TechnicianDto dto)
        {
            var isvalide = await _Context.Users.AnyAsync(u => u.Id == dto.UserId);
            if (!isvalide)
                return BadRequest($"there no Uaser with id:{dto.UserId}");

            var Tec = new Technician
            {
                UserName = dto.UserName,
                SocialSecurityNumber = dto.SocialSecurityNumber,
                AccountType = dto.AccountType,
                statusId = 1,
                UserId = dto.UserId,
                LastSigninDate = DateOnly.FromDateTime(DateTime.Now),
            };

            await _Context.Technicians.AddAsync(Tec);
            _Context.SaveChanges();
            return Ok(Tec);
        }

        [HttpPut("UpdateTechicianStatus/{Techid}")/*, Authorize(Roles = "Admin,Tech")*/]
        public async Task<ActionResult> UpdateTechicianStatus(int Techid, [FromBody] int TechStatusid)
        {
            var Tech = await _Context.Technicians.FindAsync(Techid);
            if (Tech == null)
                return BadRequest($"there are no Techician with id:{Techid}");

            var isValedStatusId = await _Context.TechnicianStatus.AnyAsync(TS => TS.Id == TechStatusid);
            if (!isValedStatusId)
                return BadRequest($"there are no Techician Status with id:{TechStatusid}");

            Tech.statusId = TechStatusid;

            _Context.Update(Tech);
            _Context.SaveChanges();

            return Ok(Tech);
        }

    }
}
