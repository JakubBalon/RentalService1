
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;



namespace RentalService.Models
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }

        [Required]
        public virtual Equipment RentedEquipment { get; set; }

        public List<Equipment> Equipments = new List<Equipment>();

        //public List<RentedEquipment> RentedEquipments = new List<RentedEquipment>();
        public int RentedEquipmentId { get; set; }


        public string RentedEquipmentName { get; set; }
        public virtual User User { get; set; }

        [Required]
        public double RentalLenght { get; set; }

        [Required]
        public double RentalPrice { get; set; }
        [Required]
        public DateTime RentalStartTime { get; set; }
        [Required]
        public DateTime RentalEndTime { get; set; }
        //public virtual Client Client { get; set; }




        public Rental(IFormCollection form, Equipment rentedEquipment, User user)
        {
            User = user;
            RentalPrice = int.Parse(form["Rental.RentalPrice"].ToString());
            RentalStartTime = DateTime.Parse(form["Rental.RentalStartTime"].ToString());
            RentalEndTime = DateTime.Parse(form["Rental.RentalEndTime"].ToString());
            RentedEquipment = rentedEquipment;
            RentedEquipmentName = rentedEquipment.EquipmentName;

        }
        public void EditRental(IFormCollection form, Equipment updatedEquipment, User user)
        {
            User = user;
            RentalPrice = int.Parse(form["Rental.RentalPrice"].ToString());
            RentalStartTime = DateTime.Parse(form["Rental.RentalStartTime"].ToString());
            RentalEndTime = DateTime.Parse(form["Rental.RentalEndTime"].ToString());
            RentedEquipment = updatedEquipment;
            RentedEquipmentName = updatedEquipment.EquipmentName;
        }

      
        public Rental() { }
    }


}

   


