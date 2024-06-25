namespace TechnicalServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public OrderStatusController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllStatus")]
        public async Task<IActionResult> GetAllStatus()
        {
            var Status = await _context.OrderStatus.ToListAsync();
            return Ok(Status);
        }

        [HttpGet("GetAllStatusById/{id}")]
        public async Task<IActionResult> GetAllStatus(int id)
        {
            var Status = await _context.OrderStatus.FindAsync(id);
            if (Status == null)
                return BadRequest($"there no Order statu with id:{id}");

            return Ok(Status);
        }


        [HttpPost("AddOrderStatus"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddOrderStatus([FromBody] OrderStatusDto dto)
        {
            var OrderStatus = new OrderStatus
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            await _context.AddAsync(OrderStatus);
            _context.SaveChanges();

            return Ok(OrderStatus);
        }
    }
}
