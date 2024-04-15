
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
        public RentalViewModel(List<Equipment> equipments)
        {



            foreach (var equipment in equipments)
            {


                Equipment.Add(new SelectListItem() { Text = equipment.EquipmentName });

            }

        }
        //Update constructor
        public RentalViewModel(Rental updatedRental, List<Equipment> equipments)
        {
            Rental = updatedRental;
            EquipName = updatedRental.RentedEquipment.EquipmentName;


            foreach (var equipment in equipments)
            {
                Equipment.Add(new SelectListItem() { Text = equipment.EquipmentName });

            }
        }

        public RentalViewModel() { }
    }
}
