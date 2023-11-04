using FoodDeliveryPlatform.Data.Core;
using FoodDeliveryPlatform.Data.Interfaces;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace FoodDeliveryPlatform.Models
{
    public class User : Entity
    {

        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Name should contain only characters.")]
        [StringLength(50, ErrorMessage = "Name should not exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        [StringLength(50, ErrorMessage = "Email should not exceed 50 variable characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Invalid phone number.")]
        [StringLength(11, ErrorMessage = "Phone number should have a maximum length of 11 digits")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(50, ErrorMessage = "Address should not exceed 50 variable characters")]
        public string DeliveryAddress { get; set; }

        public byte[] PasswordSalt { get; set; } // Store the salt used for hashing
        public string PasswordHash { get; set; } // Store the hashed password

        public void HashPassword()
        {
            if (!string.IsNullOrEmpty(Password))
            {
                using (var rng = RandomNumberGenerator.Create())
                {
                    byte[] saltBytes = new byte[16];
                    rng.GetBytes(saltBytes);
                    PasswordSalt = saltBytes;
                }

                using (var pbkdf2 = new Rfc2898DeriveBytes(Password, PasswordSalt, 10000))
                {
                    byte[] hashBytes = pbkdf2.GetBytes(32); // 32 bytes for the hash
                    PasswordHash = Convert.ToBase64String(hashBytes);
                }
            }
        }

        public bool VerifyPassword(string enteredPassword)
        {
            if (PasswordHash == null || PasswordSalt == null)
            {
                return false;
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, PasswordSalt, 10000))
            {
                byte[] testHashBytes = pbkdf2.GetBytes(32);
                return StructuralComparisons.StructuralEqualityComparer.Equals(Convert.FromBase64String(PasswordHash), testHashBytes);
            }
        }
        public List<Order> Order { get; set; }

    }
}
