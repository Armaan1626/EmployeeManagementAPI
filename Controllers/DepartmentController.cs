using Microsoft.AspNetCore.Mvc;
using EmployeeManagementAPI;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartment _repository;

        public DepartmentController(IDepartment repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllDepartment()
        {
            return Ok(_repository.GetAllDepartment());
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            var Department = _repository.GetDepartment(id);
            if (Department == null) return NotFound();
            return Ok(Department);
        }

        [HttpPost]
        public IActionResult InsertDepartment([FromBody] CreateDepartmentDto Department)
        {
            if (Department == null)
                return BadRequest("Designation data is null.");
            _repository.InsertDepartment(Department);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, [FromBody] Department Department)
        {
            if (id != Department.DepartmentID)
                return BadRequest("ID mismatch between route and body.");

            var existingDepartment = _repository.GetDepartment(id);
            if (existingDepartment == null)
                return NotFound();
            Department.DepartmentID = id;
            _repository.UpdateDepartment(Department);
            return Ok(new { message = "Updated successfully" });
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            _repository.DeleteDepartment(id);
            return Ok(new { message = "Deleted successfully" });
        }
    }
}

