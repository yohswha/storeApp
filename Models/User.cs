using System;
using System.ComponentModel.DataAnnotations;

namespace storeApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(20)]
        public string Role { get; set; } // "Buyer", "Admin", etc.

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Store hashed password
    }
}

