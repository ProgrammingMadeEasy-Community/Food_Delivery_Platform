using FoodDeliveryPlatform.Models;

namespace FoodDeliveryPlatform.Data.Core
{
    public class OrderItemRepository : Repository<OrderItem, FoodDeliveryDbContext>
    {
        public OrderItemRepository(FoodDeliveryDbContext context) : base(context)
        {
        }
    }
}
