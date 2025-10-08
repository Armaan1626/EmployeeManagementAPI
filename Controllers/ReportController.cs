using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        //test
        private readonly IReport _repository;
        //fff
        public ReportController(IReport repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetEmployeeeSalaryReport(int employeeId, int month, int year)
        {
            return Ok(_repository.GetEmployeeeSalaryReport(employeeId,  month,  year));
        }
    }
}
