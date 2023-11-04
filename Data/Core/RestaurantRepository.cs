using FoodDeliveryPlatform.Models;

namespace FoodDeliveryPlatform.Data.Core
{
    public class RestaurantRepository : Repository<Restaurant, FoodDeliveryDbContext>
    {
        public RestaurantRepository(FoodDeliveryDbContext context) : base(context)
        {

        }
    }
}
