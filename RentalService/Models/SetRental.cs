using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalService.Models
{
    public class SetRental
    {
        [Key]
        public int SetRentalId { get; set; }
        public virtual User User { get; set; }
        public string setName { get; set; }

        [ForeignKey("RentedEquipmetId")]

        public int RentedEquipmentId { get; set; }
        public Equipment RentedEquipment  { get;set; }

        public virtual Equipment ListedEquipment { get; set; }
        public string RentedEquipmentName { get; set; }

        

     
        public double SetRentalLenght { get; set; }
        public double SetRentalPrice { get; set; }
        public DateTime SetRentalStartTime { get; set; }
        public DateTime SetRentalEndTime { get; set; }



        public SetRental() { }
        public SetRental(IFormCollection form, Equipment rentedEquipment, User user)
        {
            User = user;
            setName = form["SetRental.setName"].ToString();
            SetRentalPrice = int.Parse(form["SetRental.SetRentalPrice"].ToString());
            SetRentalStartTime = DateTime.Parse(form["SetRental.SetRentalStartTime"].ToString());
            SetRentalEndTime = DateTime.Parse(form["SetRental.SetRentalEndTime"].ToString());
            RentedEquipment = rentedEquipment;
            
            

        }
        /*  public void EditSetRental(IFormCollection form, Equipment updatedEquipment1, Equipment updatedEquipment2, Equipment updatedEquipment3, User user)
          {
        x => x.EquipmentName == updatedRentalEquipment
              User = user;
              RentalPrice = int.Parse(form["Rental.RentalPrice"].ToString());
              RentalStartTime = DateTime.Parse(form["Rental.RentalStartTime"].ToString());
              RentalEndTime = DateTime.Parse(form["Rental.RentalEndTime"].ToString());
              RentedEquipment1 = updatedEquipment1;
              RentedEquipment2 = updatedEquipment2;
              RentedEquipment3 = updatedEquipment3;
              RentedEquipmentName1 = updatedEquipment1.EquipmentName;
              RentedEquipmentName2 = updatedEquipment2.EquipmentName;
              RentedEquipmentName3 = updatedEquipment3.EquipmentName;
          }*/
    }
}
