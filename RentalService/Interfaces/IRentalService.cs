
using RentalService.Helpers;
using RentalService.Models;
using RentalService.Models.ViewModels;
using System.Collections.Generic;


namespace RentalService.Interfaces
{
    public interface IRentalService
    {
        public List<Rental> GetRentals();
        public Rental GetRental( int id);
        public void CreateRental(IFormCollection form);

     
        public void UpdateRental(IFormCollection form);
        void DeleteRental(int id);
        public List<Equipment> GetEquipments();
        public Equipment GetEquipment(int id);
    }
}
