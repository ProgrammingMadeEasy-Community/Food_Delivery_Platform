namespace FoodDeliveryPlatform.Data.Interfaces
{
    public interface IEntity
    {
        public int UserID { get; set; }
        public int RestaurantID { get; set; }
        public int OrerID { get; set; }
        public int OrderItemID { get; set; }
        public int MenuItemID { get; set; }
        public int DeliveryStatusID { get; set; }
        public int DeliveryPersonnelID { get; set; }

    }
}
