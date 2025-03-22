using BackEnd.DTO;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<OrderDTO> Get()
        {
            return _orderService.GetOrders();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public OrderDTO Get(int id)
        {
            return _orderService.GetOrderById(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] OrderDTO order)
        {
            _orderService.AddOrder(order);

        }

        // PUT api/<OrderController>/5
        [HttpPut]
        public void Put([FromBody] OrderDTO order)
        {
            _orderService.UpdateOrder(order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _orderService.DeleteOrder(id);
        }
    }
}
