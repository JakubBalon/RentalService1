



using RentalService.Models;
using System.Collections.Generic;

namespace RentalService.Interfaces
{
    public interface IWarehouseService
    {

        public List<Equipment> GetEquipments(string userid);
        public Equipment GetEquipment(int id);
        public void CreateEquipment(IFormCollection form);
        public void UpdateEquipment(IFormCollection form);
        void DeleteEquipment(int id);
    }
}
