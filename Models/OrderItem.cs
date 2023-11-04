using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FoodDeliveryPlatform.Data.Interfaces;
using FoodDeliveryPlatform.Data.Core;

namespace FoodDeliveryPlatform.Models
{
    public class OrderItem : Entity
    {

        [Key]
        public int OrderItemID { get; set; }

        [ForeignKey("Order")]
        public virtual int OrderID { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("MenuItem")]
        public virtual int ItemID { get; set; }
        public virtual MenuItem MenuItem { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
        public int Quantity { get; set; }

    }
}
