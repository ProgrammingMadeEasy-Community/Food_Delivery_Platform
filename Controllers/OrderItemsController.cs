using FoodDeliveryPlatform.Data.Core;
using FoodDeliveryPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryPlatform.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly OrderItemRepository _repository;

        public OrderItemsController(OrderItemRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetAllOrderItems()
        {
            var orderItems = await _repository.GetAll();
            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItemByID(int id)
        {
            var orderItem = await _repository.Get(id);
            if (orderItem == null)
            {
                return NotFound();

            }
            return Ok(orderItem);
        }
        [HttpPost]
        public async Task<ActionResult<OrderItem>> CreateOrderItem(OrderItem orderItem)
        {
            var newOrderItem = await _repository.Add(orderItem);
            return CreatedAtAction(nameof(GetOrderItemByID), new { id = newOrderItem.OrderItemID }, newOrderItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(int id, OrderItem orderItem)
        {
            if (id != orderItem.OrderItemID)
            {
                return BadRequest();
            }

            await _repository.Update(orderItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var deletedOrderItem = await _repository.Delete(id);
            if (deletedOrderItem == null)
            {
                return NotFound();
            }

            return Ok(deletedOrderItem);
        }
    }
}
