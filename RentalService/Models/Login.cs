
using System.ComponentModel.DataAnnotations;

namespace RentalService.Models
{
    public class Login
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
