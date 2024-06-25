using Microsoft.EntityFrameworkCore;

namespace TechnicalServicesAPI.Controllers.Controller_Tec
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicionServisesController : ControllerBase
    {
        private readonly ApplicationDBContext _Context;
        public TechnicionServisesController(ApplicationDBContext Context)
        {
            _Context = Context;
        }

        [HttpGet("GetByserviceId/{ServiceId}"), Authorize(Roles = "Tech")]
        public async Task<ActionResult> GetTechniciansExtendServiceId(int ServiceId)
        {
            var technicians = await _Context.TechniciansServices.Where(t => t.ExtendServiceId == ServiceId).ToListAsync();
            return Ok(technicians);
        }

        [HttpGet("GetTechnicianServices/{id}"),Authorize(Roles = "Tech")]
        public async Task<IActionResult> GetTechnicianServices(int id)
        {
            var IsvaledTech = await _Context.Technicians.AnyAsync(t => t.Id == id);
            if (!IsvaledTech)
                return BadRequest($"there no technican with id {id}");

            var res = await _Context.TechniciansServices.Include(t => t.ExtendService).Where(e => e.TechnicianId == id).ToListAsync();

            if (res.Count == 0)
                return BadRequest("there no services to this technician");

            return Ok(res);
        }

        [HttpPost("AddTechicianServices/{Techid}")/*, Authorize(Roles = "Tech,Admin")*/]
        public async Task<ActionResult> UpdateTechicianStatus(int Techid,[FromBody] int ServicsId)
        {
            var IsValedTechId = await _Context.Technicians.AnyAsync(T => T.Id == Techid);
            if (!IsValedTechId)
                return BadRequest($"there are no Techician with id:{Techid}");

            var isValedStatusId = await _Context.ExtendServices.AnyAsync(TS => TS.Id == ServicsId);
            if (!isValedStatusId)
                return BadRequest($"there are no Techician Status with id:{ServicsId}");

            var TechService = new TechniciansServices
            {
                TechnicianId = Techid,
                ExtendServiceId = ServicsId
            };

            await _Context.TechniciansServices.AddAsync(TechService);
            _Context.SaveChanges();

            return Ok(TechService);
        }
    }
}
