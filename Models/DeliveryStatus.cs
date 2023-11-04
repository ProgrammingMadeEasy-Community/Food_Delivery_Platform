using FoodDeliveryPlatform.Data.Core;
using FoodDeliveryPlatform.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryPlatform.Models
{
    public class DeliveryStatus : Entity
    {
        [Key]
        public int DeliveryStatusID { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, ErrorMessage = "Description should not exceed 100 variable characters")]
        public string Description { get; set; }

    }
}
