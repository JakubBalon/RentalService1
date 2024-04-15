
using Microsoft.AspNetCore.Identity;
using RentalService.Helpers;

namespace RentalService.Models
{
    public class User : IdentityUser
    {

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
