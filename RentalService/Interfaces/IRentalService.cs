﻿using RentalService.Models;


namespace RentalService.Interfaces
{
    public interface IRentalService
    {
        public List<Rental> GetRentals(string userid);
        public Rental GetRental(int id);
        public void CreateRental(IFormCollection form);
        public void UpdateRental(IFormCollection form);
        void DeleteRental(int id);
        public List<Equipment> GetEquipments(string userid);
        public Equipment GetEquipment(int id);
    }
}
