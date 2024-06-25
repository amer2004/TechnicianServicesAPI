using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TechnicalServicesAPI.Models;
using TechnicalServicesAPI.Models.Technician;
using TechnicalServicesAPI.Models.User;

namespace TechnicalServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ResponsesController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllResponses/{Orderid}"), Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllResponses(int Orderid)
        {
            var IsValidOrder = await _context.Orders.AnyAsync(R => R.Id == Orderid);
            if (!IsValidOrder)
                return BadRequest($"There is no Order with this Id{Orderid}");

            var responses = await _context.Responses.Include(T => T.Technician).OrderByDescending(R => R.Date)
               .Where(R => R.OrderId==Orderid).ToListAsync();
              if (responses==null)
                return BadRequest($"There is no Responses for this Order");

              return Ok(responses);
        }

        [HttpGet("GetResponseById/{id}"), Authorize(Roles = "User")]
        public async Task<IActionResult> GetResponseById(int id)
        {
            var Response = await _context.Responses.SingleOrDefaultAsync(x => x.Id == id);
            if (Response == null)
                return BadRequest($"there is no Response with this id:{id}");

            return Ok(Response);
        }

        [HttpGet("GetResponseByTechnicianId/{Technicianid}"), Authorize(Roles = "User")]
        public async Task<IActionResult> GetResponseByTechnicianId(int Technicianid)
        {
            var Response = await _context.Responses.Where(R =>R.TechnicianId == Technicianid).ToListAsync();
            if (Response == null)
                return BadRequest($"there is no Response with this TechnicianId:{Technicianid}");
            return Ok(Response);
        }

        [HttpPost("AddResponse"), Authorize(Roles = "Tech")]
        public async Task<IActionResult> CreateResponse([FromBody] ResponseDto dto)
        {
            var IsValidOrder = await _context.Orders.AnyAsync(R => R.Id == dto.OrderId);
            if (!IsValidOrder)
                return BadRequest($"There is no Order with this id{dto.OrderId}");

            var isValidTech = await _context.Technicians.AnyAsync(x => x.Id == dto.TechnicianId);
            if (!isValidTech)
                return BadRequest("Invalid Technician Id!");

            var Responses = new Response
            {
                TechnicianId = dto.TechnicianId,
                OrderId = dto.OrderId,
                Date=dto.Date,
                Time=dto.Time,
                EstimatedTime=dto.EstimatedTime,
                EstimatedPrice=dto.EstimatedPrice,
            };

            await _context.AddAsync(Responses);
            _context.SaveChanges();
            return Ok(Responses);
        }

        [HttpDelete("DeletResponse/{Responseid}"), Authorize(Roles = "Tech")]
        public async Task<IActionResult> DeletOrders(int Responseid)
        {
            var respon = await _context.Responses.FindAsync(Responseid);
            if (respon == null)
                return BadRequest($"There is no Response With This id");

            var order = await _context.Orders.SingleOrDefaultAsync(r=>r.ChosenResponseId==Responseid);
            if (order != null)           
                return BadRequest($"The Response has been already choosen for this order");
           
            _context.Remove(respon);
            _context.SaveChanges();
            return Ok(respon);
        }
    }
}
