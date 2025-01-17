using System.ComponentModel.DataAnnotations;

namespace RentalService.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EquipmentName { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Producent { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }



        public Equipment(IFormCollection form, User user)
        {
            User = user;
            UserId = user.Id;
            EquipmentName = form["Equipment.EquipmentName"].ToString();
            Category = form["Equipment.Category"].ToString();
            Producent = form["Equipment.Producent"].ToString();



        }
        public void UpdateEquipment(Equipment updatedEquipment, IFormCollection form, User user)
        {
            User = user;
            UserId = user.Id;
            EquipmentName = form["Equipment.EquipmentName"].ToString();
            Category = form["Equipment.Category"].ToString();
            Producent = form["Equipment.Producent"].ToString();
        }

        public Equipment()
        {

        }
    }
}


