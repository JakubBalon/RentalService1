
using Microsoft.AspNetCore.Identity;

namespace RentalService.Models
{
    public class User : IdentityUser
    {

        public virtual ICollection<Rental> Rentals { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }

    }
}
