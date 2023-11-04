using FoodDeliveryPlatform.Models;

namespace FoodDeliveryPlatform.Data.Core
{
    public class OrderRepository : Repository<Order, FoodDeliveryDbContext>
    {
        public OrderRepository(FoodDeliveryDbContext context) : base(context)
        {
        }
    }
}
