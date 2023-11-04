using FoodDeliveryPlatform.Data.Core;
using FoodDeliveryPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryPlatform.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantsController : Controller
    {
        private readonly RestaurantRepository _repository;

        public RestaurantsController(RestaurantRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetAllRestaurants()
        {
            var restaurants = await _repository.GetAll();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurantByID(int id)
        {
            var restaurant = await _repository.Get(id);
            if (restaurant == null)
            {
                return NotFound();

            }
            return Ok(restaurant);
        }
        [HttpPost]
        public async Task<ActionResult<Restaurant>> CreateRestaurant(Restaurant restaurant)
        {
            var newRestaurant = await _repository.Add(restaurant);
            return CreatedAtAction(nameof(GetRestaurantByID), new { id = newRestaurant.RestaurantID }, newRestaurant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.RestaurantID)
            {
                return BadRequest();
            }

            await _repository.Update(restaurant);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var deletedRestaurant = await _repository.Delete(id);
            if (deletedRestaurant == null)
            {
                return NotFound();
            }

            return Ok(deletedRestaurant);
        }
    }
}
