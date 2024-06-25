using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalServicesAPI.Dtos.Technician;

namespace TechnicalServicesAPI.Controllers.Controller_Tec
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianStatusController : ControllerBase
    {
        private readonly ApplicationDBContext _Context;
        public TechnicianStatusController(ApplicationDBContext context)
        {
            _Context = context;
        }

        [HttpGet("GetTechnicianStatuses"), Authorize(Roles = "Tech")]
        public async Task<ActionResult> GetTechniciansStatuses()
        {
            var technicianStatuses = await _Context.TechnicianStatus.ToListAsync();
            return Ok(technicianStatuses);
        }

        [HttpGet("GetTechnicianStatus/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult>GetTechnicianStatus(int id)
        {
            var technicianStatus = await _Context.TechnicianStatus.SingleOrDefaultAsync(x=>x.Id==id);

            if (technicianStatus == null)
                return BadRequest();

            return Ok(technicianStatus);
        }

        [HttpPost("AddStatus"), Authorize(Roles = "Admin")]
        public async Task<ActionResult>AddStatus(TechnicianStatusDto dto)
        {
            var state = new TechnicianStatus 
            { 
                Name = dto.Name,
                Description = dto.Description, 
            };

             await  _Context.TechnicianStatus.AddAsync(state);
            _Context.SaveChanges();
            return Ok(state);
        }
    }
}
