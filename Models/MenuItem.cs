using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FoodDeliveryPlatform.Data.Interfaces;
using FoodDeliveryPlatform.Data.Core;

namespace FoodDeliveryPlatform.Models
{
    public class MenuItem : Entity
    {
        [Key]
        public int ItemID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Name should contain only characters.")]
        [StringLength(50, ErrorMessage = "Name should not exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(50, ErrorMessage = "Description should not exceed 50 variable characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public double Price { get; set; }
        public string Category { get; set; }

        [ForeignKey("Restaurant")]
        public virtual int RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }

    }
}
