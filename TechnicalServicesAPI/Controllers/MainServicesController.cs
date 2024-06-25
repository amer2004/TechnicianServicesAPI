namespace TechnicalServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainServicesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public MainServicesController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllMainServices")]
        public async Task<IActionResult> GetAllMainServices()
        {
            var Serv = await _context.MainServices.ToListAsync();
            return Ok(Serv);
        }

        [HttpGet("GetMainServicesById/{id}")]
        public async Task<IActionResult> GetMainServicesById(int id)
        {
            var Serv = await _context.MainServices.FindAsync(id);
            if (Serv == null)
                return BadRequest($"there no main service with id:{id}");

            return Ok(Serv);
        }

        [HttpPost("AddMainServices")/*, Authorize(Roles = "Admin")*/]
        public async Task<IActionResult> AddServices([FromBody] MainServiceDto dto)
        {
            var Service = new MainService
            {
                Name = dto.Name,
            };
            await _context.AddAsync(Service);
            _context.SaveChanges();
            return Ok(Service);
        }
    }
}
