using Microsoft.AspNetCore.Mvc.Rendering;

namespace RentalService.Models.ViewModels
{
    public class EquipmentViewModel
    {
        public Equipment Equipment { get; set; }

        public EquipmentViewModel(Equipment equipment)
        {

          
        }  
        public EquipmentViewModel()
        {

          
        }
    }
}
