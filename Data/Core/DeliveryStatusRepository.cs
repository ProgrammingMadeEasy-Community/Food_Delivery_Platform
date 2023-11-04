using FoodDeliveryPlatform.Models;

namespace FoodDeliveryPlatform.Data.Core
{
    public class DeliveryStatusRepository : Repository<DeliveryStatus, FoodDeliveryDbContext>
    {
        public DeliveryStatusRepository(FoodDeliveryDbContext context) : base(context)
        {
        }
    }
}
