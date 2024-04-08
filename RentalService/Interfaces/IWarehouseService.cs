



using RentalService.Models;
using System.Collections.Generic;

namespace RentalService.Interfaces
{
    public interface IWarehouseService
    {

        int Save(Equipment equipment); // Zapisywanie equipmentu do bazy

       // int Update(int id);

        List<Equipment> GetEquipments();

        Equipment GetEquipment(int id);

        int Delete(int id);
    }
}
