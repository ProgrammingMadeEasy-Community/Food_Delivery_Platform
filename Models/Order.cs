using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FoodDeliveryPlatform.Data.Interfaces;
using FoodDeliveryPlatform.Data.Core;

namespace FoodDeliveryPlatform.Models
{
    public class Order : Entity
    {

        [Key]
        public int OrderID { get; set; }

        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        public double TotalAmount { get; set; }

        [ForeignKey("User")]
        public virtual int UserID { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Restaurant")]
        public virtual int RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }

    }
}
