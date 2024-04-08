

using RentalService.Models;
using Microsoft.EntityFrameworkCore;
using RentalService.Interfaces;
using RentalService.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace RentalService.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly RentalDbContext _context;

        public WarehouseService(RentalDbContext context)
        {
            _context = context;
        }




        public int Delete(int id)
        {
            var equipment = _context.Equipments.Find(id);
            _context.Equipments.Remove(equipment);
            _context.SaveChanges();

            return id;
        }

        public Equipment GetEquipment(int id)
        {
            var equipment = _context.Equipments.Find(id);
            return equipment;
        }

        public List<Equipment> GetEquipments() //Pokazywanie tabeli z bazy danych w widoku
        {
            var equipments = _context.Equipments.ToList();
            return equipments;
        }

        public int Save(Equipment equipment)
        {
            _context.Add(equipment);

            _context.SaveChanges();


            return equipment.Id;
        }

     /*   public void Update(int id)
        {


            var @equipment = _context.Get((int)id);

            if (@equipment == null)
            {
                return NotFound();
            }

            return View(@equipment);
        }*/
    }
}
