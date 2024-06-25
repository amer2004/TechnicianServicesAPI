namespace TechnicalServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly ApplicationDBContext _context;
        public OrdersController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllOrders"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllOrders()
        {
            var Orders = await _context.Orders.OrderByDescending(O => O.Date).ToListAsync();
            return Ok(Orders);
        }

        [HttpGet("GetOrderById/{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetOrdersById(int id)
        {
            var Orders = await _context.Orders.SingleOrDefaultAsync(x => x.Id == id);
            if (Orders == null)
                return BadRequest($"there is no order with this id:{id}");

            return Ok(Orders);
        }

        [HttpGet("GetUserOrders/{Userid}"), Authorize(Roles = "User")]
        public async Task<IActionResult> GetOrderByUserId(int Userid)
        {
            var IsValidUser = await _context.Users.AnyAsync(U => U.Id == Userid);
            if (!IsValidUser)
                return BadRequest($"There is no User with this Id{Userid}");

            var orders = await _context.Orders.Include(o => o.ExtendService).Include(o => o.Status).Include(R => R.Responses).Where(O => O.UserId == Userid && O.StatusId != 1 && O.StatusId != 7).ToListAsync();
            if (orders == null)
                return BadRequest($"there is no order with this UserId:{Userid}");

            return Ok(orders);
        }

        [HttpGet("GetTechOrders/{techid}"), Authorize(Roles = "Tech")]
        public async Task<IActionResult> GetTechOrders(int techid)
        {
            var IsValedtech = await _context.Technicians.AnyAsync(t => t.Id == techid);
            if (!IsValedtech)
                return BadRequest($"there no technician withthis id:{techid}");

            var orders = await _context.Orders.Include(o => o.ChosenResponse).Include(o => o.User).Include(o => o.ExtendService).Include(o => o.Status).Where(o => o.ChosenResponse.TechnicianId == techid && o.StatusId != 1).ToListAsync();
            return Ok(orders);
        }

        [HttpGet("GetTechNewOrders/{techid}"), Authorize(Roles = "Tech")]
        public async Task<IActionResult> GetTechNewOrders(int techid)
        {
            var IsValedtech = await _context.Technicians.Include(t=>t.User).FirstOrDefaultAsync(t=>t.Id==techid);
            if (IsValedtech == null)
                return BadRequest($"there no technician withthis id:{techid}");

            var extendservics = await _context.TechniciansServices.Include(S => S.ExtendService).Where(S => S.TechnicianId == techid).ToListAsync();
            if (extendservics.Count == 0)
                return BadRequest("there no services to this tech");

            List<Order> orders = new();
            var res = await _context.Orders.Include(o => o.ExtendService).Include(o => o.Status).Where(o => o.ChosenResponseId == null && o.UserId != IsValedtech.User.Id && o.StatusId != 1).ToListAsync();

            foreach (var item in res)

                foreach (var E in extendservics)

                    if (E.ExtendServiceId == item.ExtendServiceId)
                        orders.Add(item);

            return Ok(orders);
        }

        [HttpGet("GetOrderByOrderNumber/{OrderNumber}"), Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetOrderByOrderNumber(int OrderNumber)
        {
            var Orders = await _context.Orders.Where(O => O.Id == OrderNumber).ToListAsync();
            if (Orders == null)
                return BadRequest($"there is no order with this OrderNumber:{OrderNumber}");

            return Ok(Orders);
        }

        [HttpPost("AddOrder"), Authorize(Roles = "User")]
        public async Task<IActionResult> AddOrder([FromBody] OrderDto dto)
        {
            var isValidUser = await _context.Users.AnyAsync(x => x.Id == dto.UserId);
            if (!isValidUser)
                return BadRequest("Invalid User Id!");

            var IsValidServ = await _context.ExtendServices.AnyAsync(S => S.Id == dto.ExtendServiceId);
            if (!IsValidServ)
                return BadRequest("Invalid ExtendService Id!");

            var Order = new Order
            {
                UserId = dto.UserId,
                ExtendServiceId = dto.ExtendServiceId,
                Date = DateOnly.FromDateTime(DateTime.Now),
                XLocation = dto.XLocation,
                YLocation = dto.YLocation,
                Description = dto.Description,
                StatusId = 3
            };

            await _context.AddAsync(Order);
            _context.SaveChanges();

            return Ok(Order);
        }

        [HttpPut("UpdateOrderStatus/{Orderid}"), Authorize(Roles = "User")]
        public async Task<IActionResult> UpditOrderStatus(int Orderid, [FromBody] int Statusid)
        {
            var order = await _context.Orders.FindAsync(Orderid);
            if (order == null)
                return BadRequest($"There is no Order with This id{Orderid}");

            var OrderStatus = await _context.OrderStatus.FindAsync(Statusid);
            if (OrderStatus == null)
                return BadRequest($"There no status With This id{Statusid}");

            order.StatusId = Statusid;

            _context.Update(order);
            _context.SaveChanges();

            return Ok(order);
        }

        [HttpPut("ChooseResponse/{Orderid}"), Authorize(Roles = "User")]
        public async Task<IActionResult> ChooseResponse(int Orderid, [FromBody] int Responsid)
        {
            var order = await _context.Orders.FindAsync(Orderid);
            if (order == null)
                return BadRequest($"There is no Order with This id{Orderid}");

            var OrderStatus = await _context.Responses.FindAsync(Responsid);
            if (OrderStatus == null)
                return BadRequest($"There no status With This id{Responsid}");

            if (order.ChosenResponseId != null)
                return BadRequest("you already choose a responce to this order");

            order.ChosenResponseId = Responsid;

            _context.Update(order);
            _context.SaveChanges();

            return Ok(order);
        }
    }
}
