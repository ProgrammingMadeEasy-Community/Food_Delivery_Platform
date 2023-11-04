using FoodDeliveryPlatform.Data.Core;
using FoodDeliveryPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryPlatform.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserRepository _repository;

        public UsersController(UserRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _repository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByID(int id)
        {
            var user = await _repository.Get(id);
            if (user == null)
            {
                return NotFound();

            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            var newUser = await _repository.Add(user);
            return CreatedAtAction(nameof(GetUserByID), new { id = newUser.UserID }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            await _repository.Update(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deletedUser = await _repository.Delete(id);
            if (deletedUser == null)
            {
                return NotFound();
            }

            return Ok(deletedUser);
        }
    }
}
