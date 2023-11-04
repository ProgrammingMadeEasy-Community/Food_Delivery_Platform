using FoodDeliveryPlatform.Data.Core;
using FoodDeliveryPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryPlatform.Controllers
{
    public class MenuItemsController : Controller
    {
        private readonly MenuItemRepository _repository;

        public MenuItemsController(MenuItemRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetAllMenuItems()
        {
            var menuItems = await _repository.GetAll();
            return Ok(menuItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItemByID(int id)
        {
            var menuItem = await _repository.Get(id);
            if (menuItem == null)
            {
                return NotFound();

            }
            return Ok(menuItem);
        }
        [HttpPost]
        public async Task<ActionResult<MenuItem>> CreateMenuItem(MenuItem menuItem)
        {
            var newMenuItem = await _repository.Add(menuItem);
            return CreatedAtAction(nameof(GetMenuItemByID), new { id = newMenuItem.MenuItemID }, newMenuItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, MenuItem menuItem)
        {
            if (id != menuItem.MenuItemID)
            {
                return BadRequest();
            }

            await _repository.Update(menuItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var deletedMenuItem = await _repository.Delete(id);
            if (deletedMenuItem == null)
            {
                return NotFound();
            }

            return Ok(deletedMenuItem);
        }
    }
}
