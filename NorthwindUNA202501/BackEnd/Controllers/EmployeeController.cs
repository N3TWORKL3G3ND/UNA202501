using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<EmployeeDTO> Get()
        {
            return _employeeService.GetEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public EmployeeDTO Get(int id)
        {
            return _employeeService.GetEmployeeById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] EmployeeDTO employee)
        {
            _employeeService.AddEmployee(employee);

        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public void Put([FromBody] EmployeeDTO employee)
        {
            _employeeService.UpdateEmployee(employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
        }
    }
}
