

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
        private readonly RentalDbContext _rentalDbContext;

        public WarehouseService(RentalDbContext rentalDbContext)
        {
            _rentalDbContext = rentalDbContext;
        }
        public List<Equipment> GetEquipments(string userid)
        {

            return _rentalDbContext.Equipments.Where(x => x.User.Id == userid).ToList();
        }
        public Equipment GetEquipment(int id)
        {


            return _rentalDbContext.Equipments.FirstOrDefault(x => x.Id == id);

        }



        public void CreateEquipment(IFormCollection form)
        {
            
            var user = _rentalDbContext.Users.FirstOrDefault(x => x.Id == form["UserId"].ToString());
            var newEquipment = new Equipment(form, user);
            _rentalDbContext.Equipments.Add(newEquipment);
            _rentalDbContext.SaveChanges();
        }

        public void UpdateEquipment(IFormCollection form)
        {
            var user = _rentalDbContext.Users.FirstOrDefault(x => x.Id == form["UserId"].ToString());
            int updatedEquipmentId = int.Parse(form["Equipment.Id"]);
            var updatedEquipment = _rentalDbContext.Equipments.FirstOrDefault(x=>x.Id == updatedEquipmentId);
            _rentalDbContext.Entry(updatedEquipment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _rentalDbContext.SaveChanges();
        }
        public void DeleteEquipment(int id)
        {
            var equipment = _rentalDbContext.Equipments.Find(id);
            _rentalDbContext.Equipments.Remove(equipment);
            _rentalDbContext.SaveChanges();
        }
    }
}
