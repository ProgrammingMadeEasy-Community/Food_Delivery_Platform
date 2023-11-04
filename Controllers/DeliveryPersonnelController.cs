using FoodDeliveryPlatform.Data.Core;
using FoodDeliveryPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryPlatform.Controllers
{
    [Route("api/deliverypersonnels")]
    [ApiController]
    public class DeliveryPersonnelController : Controller
    {
        private readonly DeliveryPersonnelRepository _repository;

        public DeliveryPersonnelController(DeliveryPersonnelRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryPersonnel>>> GetDeliveryPersonnels()
        {
            var deliverypersonnel = await _repository.GetAll();
            return Ok(deliverypersonnel);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryPersonnel>> GetDeliveryPersonnelByID(int id)
        {
            var deliverypersonnel = await _repository.Get(id);
            if (deliverypersonnel == null)
            {
                return NotFound();
            }
            return Ok(deliverypersonnel);
        }
        [HttpPost]
        public async Task<ActionResult<DeliveryPersonnel>> CreateUser(DeliveryPersonnel deliveryPersonnel)
        {
            var personnel = await _repository.Add(deliveryPersonnel);
            return CreatedAtAction(nameof(GetDeliveryPersonnelByID), new { id = personnel.DeliveryPersonnelID }, personnel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeliveryPersonnel(int id, DeliveryPersonnel deliveryPersonnel)
        {
            if (id != deliveryPersonnel.DeliveryPersonnelID)
            {
                return BadRequest();
            }

            await _repository.Update(deliveryPersonnel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryPersonnel(int id)
        {
            var deletedPersonnel = await _repository.Delete(id);
            if (deletedPersonnel == null)
            {
                return NotFound();
            }

            return Ok(deletedPersonnel);
        }
    }
}
