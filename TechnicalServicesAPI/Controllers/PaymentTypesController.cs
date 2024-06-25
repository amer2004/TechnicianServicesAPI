namespace TechnicalServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypesController : ControllerBase
    {
        private readonly ApplicationDBContext _Context;

        public PaymentTypesController(ApplicationDBContext context)
        {
            _Context = context;
        }

        [HttpGet("GetPaymentTypes"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPaymentTypes()
        {
            var types = await _Context.PaymentTypes.ToListAsync();
            return Ok(types);
        }

        [HttpGet("GetPaymentType/{id}"), Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetPaymentType(int id)
        {
            var type = await _Context.PaymentTypes.FindAsync(id);
            if (type == null)
                return BadRequest($"there are no Payment Type with id:{id}");

            return Ok(type);
        }

        [HttpPost("AddPaymentType"), Authorize(Roles = "Admin")]
        public IActionResult AddPaymentType(PaymentTypeDto dto)
        {
            if (dto.Amount == 0)
                return BadRequest("the amount can not be 0");

            var Type = new PaymentType
            {
                Amount = dto.Amount,
                Name = dto.Name,
                Description = dto.Description,
            };
            _Context.PaymentTypes.Add(Type);
            _Context.SaveChanges();
            return Ok(Type);
        }

        [HttpPut("UpdatePaymetTypeAmount/{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditPaymetTypeAmount(int id,double NewAmount)
        {
            var type = await _Context.PaymentTypes.FindAsync(id);
            if (type == null)
                return BadRequest($"there are no Payment Type with id:{id}");

            type.Amount = NewAmount;
            _Context.Update(type);

            _Context.SaveChanges();
            return Ok(type);
        }

    }
}
