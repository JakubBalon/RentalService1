

using System.ComponentModel.DataAnnotations;

namespace RentalService.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Podanie nazwy jest wymagane")]
        public string EquipmentName { get; set; }
        [Required(ErrorMessage = "Podanie kategorii jest wymagane")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Podanie producenta jest wymagane")]
        public string Producent { get; set; }
    }
}


