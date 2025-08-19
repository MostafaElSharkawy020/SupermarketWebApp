using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SupermarketWebApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 chars")]
        [DataType(DataType.Password)]
        public string password { get; set; } //Hashed password

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string confirmPassword { get; set; }

        [Required]
        [Phone]
        public string phoneNumber { get; set; }


        [Required]
        public string address { get; set; }

    }
}
