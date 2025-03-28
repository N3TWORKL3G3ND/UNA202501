using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerDTO> Get()
        {
            return _customerService.GetCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerDTO Get(string id)
        {
            return _customerService.GetCustomerById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] CustomerDTO customer)
        {
            _customerService.AddCustomer(customer);

        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public void Put([FromBody] CustomerDTO customer)
        {
            _customerService.UpdateCustomer(customer);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete]
        public void Delete(string id)
        {
            _customerService.DeleteCustomer(id);
        }
    }
}
