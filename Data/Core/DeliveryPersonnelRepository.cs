using FoodDeliveryPlatform.Models;

namespace FoodDeliveryPlatform.Data.Core
{
    public class DeliveryPersonnelRepository : Repository<DeliveryPersonnel, FoodDeliveryDbContext>
    {
        public DeliveryPersonnelRepository(FoodDeliveryDbContext context) : base(context)
        {
        }
    }
}
