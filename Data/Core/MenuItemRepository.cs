using FoodDeliveryPlatform.Models;

namespace FoodDeliveryPlatform.Data.Core
{
    public class MenuItemRepository : Repository<MenuItem, FoodDeliveryDbContext>
    {
        public MenuItemRepository(FoodDeliveryDbContext context) : base(context)
        {
        }
    }
}
