using FoodDeliveryPlatform.Models;

namespace FoodDeliveryPlatform.Data.Core
{
    public class UserRepository : Repository<User, FoodDeliveryDbContext>
    {
        public UserRepository(FoodDeliveryDbContext context) : base(context)

        {

        }
    }
}
