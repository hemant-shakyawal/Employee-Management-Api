using Employee_Management_Api.Models;
using Employee_Management_Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;

namespace Employee_Management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController:ControllerBase
    {

        private readonly IEmpolyeeRepository _employeeRepository;

        public EmployeeController(IEmpolyeeRepository empolyeeRepository)
        {
            _employeeRepository = empolyeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeeasync()
        {
            var allEmployee=await _employeeRepository.GetAllAsync();
            return Ok(allEmployee);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>>GetEmployeeById(int id)
        {

            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null) {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new
            {
                id = employee.Id
            }, employee);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeById(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
