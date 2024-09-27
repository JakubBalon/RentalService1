namespace RentalService.Models
{
    public class RentedEquipment
    {
        public Equipment Equipment { get; set; }

        public int EquipmentId {  get; set; }

        public Rental Rental { get; set; }

        public int RentalId { get; set; }
    }
}
