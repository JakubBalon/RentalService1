
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;



namespace RentalService.Models
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }
        public  Equipment RentedEquipment { get; set; }

        public string RentedEquipmentName { get; set; }

        public double RentalLenght { get; set; }
        public double RentalPrice { get; set; }
        public DateTime RentalStartTime { get; set; }
        public DateTime RentalEndTime { get; set; }
        //public virtual Client Client { get; set; }



        public Rental(IFormCollection form, Equipment rentedEquipment)
        {

            RentalPrice = int.Parse(form["Rental.RentalPrice"].ToString());
            RentalStartTime = DateTime.Parse(form["Rental.RentalStartTime"].ToString());
            RentalEndTime = DateTime.Parse(form["Rental.RentalEndTime"].ToString());
            RentedEquipment = rentedEquipment;
            RentedEquipmentName = rentedEquipment.EquipmentName;
            
        }
        public void EditRental(IFormCollection form, Equipment updatedEquipment)
        {
            RentalPrice = int.Parse(form["Rental.RentalPrice"].ToString());
            RentalStartTime = DateTime.Parse(form["Rental.RentalStartTime"].ToString());
            RentalEndTime = DateTime.Parse(form["Rental.RentalEndTime"].ToString());
            RentedEquipment = updatedEquipment;
            RentedEquipmentName = updatedEquipment.EquipmentName;
        }

      
        public Rental() { }
    }


}

   


