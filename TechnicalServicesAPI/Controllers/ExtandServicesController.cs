namespace TechnicalServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtandServicesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ExtandServicesController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllExtandServices")]
        public async Task<IActionResult> GetAllExtandServices()
        {
            var ExServ = await _context.ExtendServices.ToListAsync();
            return Ok(ExServ);
        }

        [HttpGet("GetByMainServiceId/{id}")]
        public async Task<IActionResult> GetByMaunServceId(int id)
        {
            var isvaledMainService = await _context.MainServices.AnyAsync(M => M.Id == id);
            if (!isvaledMainService)
                return BadRequest($"There no Main Service With Id:{id}");

            var services = await _context.ExtendServices.Where(S => S.MainServiceId == id).ToListAsync();
            if (services == null)
                return BadRequest("ther no Extand Services to this Main Service");

            return Ok(services);
        }

        [HttpPost("AddExtandServices")/*, Authorize(Roles = "Admin")*/]
        public async Task<IActionResult> AddExtandServices([FromBody] ExtendServiceDto dto)
        {
            var ExService = new ExtendService
            {
                MainServiceId = dto.MainServiceId,
                Name = dto.Name,
            };

            await _context.AddAsync(ExService);
            _context.SaveChanges();

            return Ok(ExService);
        }
    }
}
