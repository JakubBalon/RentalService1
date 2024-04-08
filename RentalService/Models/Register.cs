
using System.ComponentModel.DataAnnotations;

namespace RentalService.Models
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public string UserName { get; set; }
    }
}
