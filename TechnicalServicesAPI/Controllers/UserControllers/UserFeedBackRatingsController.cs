namespace TechnicalServicesAPI.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFeedBackRatingsController : ControllerBase
    {
        ApplicationDBContext _Context;
        public UserFeedBackRatingsController(ApplicationDBContext context)
        {
            _Context = context;
        }

        [HttpGet("GetByOrderId/{Orderid}")]
        public async Task<IActionResult> GetByOrderId(int Orderid)
        {
            var IsValidOrder = await _Context.Orders.AnyAsync(o => o.Id == Orderid);
            if (!IsValidOrder)
                return BadRequest($"There no Order With Id:{Orderid}");

            var FeedBack = await _Context.UsersFeedBack.FirstOrDefaultAsync(f => f.OrderId == Orderid);
            if (FeedBack == null)
                return BadRequest("There no Feed to this order");

            var ratings = await _Context.UsersFeedBackRatings.Where(fb => fb.UserFeedBackId == FeedBack.Id).ToListAsync();
            return Ok(ratings);
        }

        [HttpPost("AddUserFeedBackRatings"), Authorize(Roles = "User")]
        public async Task<IActionResult> AddUserFeedBackRatings(List<UserFeedBackRatingDto> dtos)
        {
            var FeedBack = await _Context.UsersFeedBack.FindAsync(dtos[0].UserFeedBackId);
            if (FeedBack == null)
                return BadRequest($"there no feed back with this id:{dtos[0].UserFeedBackId}");

            var order = await _Context.Orders.Include(o => o.ChosenResponse.Technician).FirstOrDefaultAsync(o => o.Id == FeedBack.OrderId);
            if (order == null)
                return BadRequest($"there no order to this feed back");

            var tech = order.ChosenResponse?.Technician;

            if (tech == null)
                return BadRequest("the order dose not have a technician");

            foreach (var item in dtos)
            {
                var userfeedbackrating = new UserFeedBackRating
                {
                    RatingTypeId = item.RatingTypeId,
                    Value = item.Value,
                    UserFeedBackId = item.UserFeedBackId,
                };
                _Context.Add(userfeedbackrating);
            }

            var Ratings = await _Context.TechniciansRatings.Include(R => R.RatingType).Where(R => R.TechnicianId == tech.Id).ToListAsync();
            foreach (var item in Ratings)
            {
                item.Value = ((item.Value*9) + dtos.FirstOrDefault(d => d.RatingTypeId == item.RatingTypeId).Value) / 10;
                _Context.Update(item);
            }
            await _Context.SaveChangesAsync();

            return Ok(true);
        }

    }
}
