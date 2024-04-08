
using System.ComponentModel.DataAnnotations;

namespace RentalService.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public int ClientName { get; set; }
        public int ClientPhone { get; set; }
    }
}
