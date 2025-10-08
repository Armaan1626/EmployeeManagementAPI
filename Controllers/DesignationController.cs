using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : Controller
    {
        private readonly IDesignation _designations;
        public DesignationController(IDesignation designations)
        {
            _designations = designations;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Designation>> GetAllDesignation()
        {
            return _designations.GetAllDesignation();
        }

        [HttpGet("{id}")]
        public ActionResult<Designation> GetDesignationById(int id)
        {
            return _designations.GetDesignation(id);
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteDesignation(int id)
        {
            _designations.DeleteDesignation(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDesignation(int id, [FromBody] Designation designation)
        {
            if (id != designation.DesignationId)
                return BadRequest("ID mismatch between route and body.");

            var existingDesignation = _designations.GetDesignation(id);
            if (existingDesignation == null)
                return NotFound();

            _designations.UpdateDesignation(designation);
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertDesignation([FromBody] CreateDesignationDto designation)
        {
            if (designation == null)
                return BadRequest("Designation data is null.");

            _designations.InsertDesignation(designation);

            return Ok();
        }
    }
}
