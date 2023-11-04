using FoodDeliveryPlatform.Data.Core;
using FoodDeliveryPlatform.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryPlatform.Models
{
    public class DeliveryPersonnel : Entity
    {
        [Key]
        public int DeliveryPersonnelID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Name should contain only characters.")]
        [StringLength(50, ErrorMessage = "Name should not exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Invalid phone number.")]
        [StringLength(11, ErrorMessage = "Contact number should have a maximum length of 11 digits")]
        public string ContactNumber { get; set; }

    }
}
