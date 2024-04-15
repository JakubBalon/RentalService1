namespace RentalService.Models.ViewModels
{
    public class EquipmentViewModel
    {
        public Equipment Equipment { get; set; }
        public string UserId { get; set; }
        public string EquipName { get; set; }
        public EquipmentViewModel(string userid)
        {
            UserId = userid;
        }

        public EquipmentViewModel(Equipment updatedEquipment, string userid)
        {
            UserId = userid;
            Equipment = updatedEquipment;
            EquipName = updatedEquipment.EquipmentName;
        }

        public EquipmentViewModel()
        {

        }
    }
}
