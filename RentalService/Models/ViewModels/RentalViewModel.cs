using Microsoft.AspNetCore.Mvc.Rendering;

namespace RentalService.Models.ViewModels
{

    public class RentalViewModel
    {
        public Rental Rental { get; set; }

        public List<SelectListItem> Equipment = new List<SelectListItem>();
        public string EquipName { get; set; }
        public string UserId { get; set; }




        //Create constructor
        public RentalViewModel(List<Equipment> equipments, string userid)
        {
            UserId = userid;


            foreach (Equipment equipment in equipments)
                if (equipment.UserId == UserId)
                {

                    Equipment.Add(new SelectListItem() { Text = equipment.EquipmentName });

                }



        }
        //Update constructor
        public RentalViewModel(Rental updatedRental, List<Equipment> equipments, string userid)
        {
            UserId = userid;
            Rental = updatedRental;
            EquipName = updatedRental.RentedEquipment.EquipmentName;


            foreach (var equipment in equipments)
                if (equipment.UserId == UserId)
                {

                    Equipment.Add(new SelectListItem() { Text = equipment.EquipmentName });

                }
        }

        public RentalViewModel() { }
    }


}
