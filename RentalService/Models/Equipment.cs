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


        public User User { get; set; }

        public string UserId { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<SetRental> SetRentals { get; set; }



        public Equipment(IFormCollection form, User user)
        {
            User = user;
            UserId = user.Id;
            EquipmentName = form["Equipment.EquipmentName"].ToString();
            Category = form["Equipment.Category"].ToString();
            Producent = form["Equipment.Producent"].ToString();



        }
        public void UpdateEquipment(IFormCollection form, User user)
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


