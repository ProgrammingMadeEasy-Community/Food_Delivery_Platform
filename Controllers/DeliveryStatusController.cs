using FoodDeliveryPlatform.Data.Core;
using FoodDeliveryPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryPlatform.Controllers
{

    [Route("api/deliverystatuses")]
    [ApiController]
    public class DeliveryStatusController : ControllerBase
    {
        private readonly DeliveryStatusRepository _repository;

        public DeliveryStatusController(DeliveryStatusRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryStatus>>> GetDeliveryStatuses()
        {
            var deliveryStatuses = await _repository.GetAll();
            return Ok(deliveryStatuses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryStatus>> GetDeliveryStatusByID(int id)
        {
            var deliveryStatus = await _repository.Get(id);

            if (deliveryStatus == null)
            {
                return NotFound();
            }

            return Ok(deliveryStatus);
        }

        [HttpPost]
        public async Task<ActionResult<DeliveryStatus>> CreateUser(DeliveryStatus deliveryStatus)
        {
            var addedStatus = await _repository.Add(deliveryStatus);
            return CreatedAtAction(nameof(GetDeliveryStatusByID), new { id = addedStatus.DeliveryStatusID }, addedStatus);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeliveryStatus(int id, DeliveryStatus deliveryStatus)
        {
            if (id != deliveryStatus.DeliveryStatusID)
            {
                return BadRequest();
            }

            await _repository.Update(deliveryStatus);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryStatus(int id)
        {
            var deletedStatus = await _repository.Delete(id);
            if (deletedStatus == null)
            {
                return NotFound();
            }

            return Ok(deletedStatus);
        }
    }

}
