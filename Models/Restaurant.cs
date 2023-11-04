using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FoodDeliveryPlatform.Data.Interfaces;
using FoodDeliveryPlatform.Data.Core;

namespace FoodDeliveryPlatform.Models
{
    public class Restaurant : Entity
    {
        [Key]
        public int RestaurantID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Name should contain only characters.")]
        [StringLength(50, ErrorMessage = "Name should not exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, ErrorMessage = "Description should not exceed 100 variable characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Invalid phone number.")]
        [StringLength(11, ErrorMessage = "Contact number should have a maximum length of 11 digits.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(50, ErrorMessage = "Address should not exceed 50 variable characters")]
        public string Address { get; set; }

        [ForeignKey("User")]
        public virtual int OwnerID { get; set; }
        public virtual User User { get; set; }

        public List<Order> Order { get; set; }

    }
}
