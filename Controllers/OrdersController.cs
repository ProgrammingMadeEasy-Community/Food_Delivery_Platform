using FoodDeliveryPlatform.Data.Core;
using FoodDeliveryPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryPlatform.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderRepository _repository;

        public OrdersController(OrderRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _repository.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderByID(int id)
        {
            var order = await _repository.Get(id);
            if (order == null)
            {
                return NotFound();

            }
            return Ok(order);
        }
        [HttpPost]
        public async Task<ActionResult<Order>> CreateRestaurant(Order order)
        {
            var newOrder = await _repository.Add(order);
            return CreatedAtAction(nameof(GetOrderByID), new { id = newOrder.OrerID }, newOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            if (id != order.OrerID)
            {
                return BadRequest();
            }

            await _repository.Update(order);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var deletedOrder = await _repository.Delete(id);
            if (deletedOrder == null)
            {
                return NotFound();
            }

            return Ok(deletedOrder);
        }
    }
}
