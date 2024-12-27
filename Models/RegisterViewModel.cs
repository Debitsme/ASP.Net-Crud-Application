using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MyApp.Models
{
    public class RegisterViewModel  
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required  string Password { get; set; }
    }
}
