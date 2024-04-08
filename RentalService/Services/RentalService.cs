using Microsoft.AspNetCore.Http;
using RentalService.Interfaces;
using RentalService.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentalService.Models.ViewModels;

namespace RentalService.Services.Interfaces
{


    public class RentalService : IRentalService
    {
        private readonly RentalDbContext _rentalDbContext;

        public RentalService(RentalDbContext rentalDbContext)
        {
            _rentalDbContext = rentalDbContext;
        }
        public List<Rental> GetRentals()
        {
            var rentals = _rentalDbContext.Rentals.ToList();
            return rentals;
        }
        public Rental GetRental(int id)
        {


            return _rentalDbContext.Rentals.FirstOrDefault(x => x.RentalId == id);

        }

       

        public void CreateRental(IFormCollection form)
        {
            var rentedEquipment = form["Equipment"].ToString();
            //var user = _rentalDbContext.Users.FirstOrDefault(x => x.Id == form["UserId"].ToString());
            var newrental = new Rental(form, _rentalDbContext.Equipments.FirstOrDefault(x => x.EquipmentName == rentedEquipment));
            _rentalDbContext.Rentals.Add(newrental);
            _rentalDbContext.SaveChanges();
        }
        public void UpdateRental(IFormCollection form)
        {
            var updatedRentalEquipment = form["Equipment"].ToString();
            int updatedRentalId = int.Parse(form["Rental.RentalId"]);
            var updatedRental = _rentalDbContext.Rentals.FirstOrDefault(x => x.RentalId == updatedRentalId);
            var equipment = _rentalDbContext.Equipments.FirstOrDefault(x => x.EquipmentName == updatedRentalEquipment);
            var user = _rentalDbContext.Users.FirstOrDefault(x => x.Id == form["UserId"].ToString());
            updatedRental.EditRental (form, equipment);
            _rentalDbContext.Entry(updatedRental).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _rentalDbContext.SaveChanges();

        }
        public void DeleteRental(int id)
        {
            var rental = _rentalDbContext.Rentals.Find(id);
            _rentalDbContext.Rentals.Remove(rental);
            _rentalDbContext.SaveChanges();
        }

        public List<Equipment> GetEquipments()
        {
            return _rentalDbContext.Equipments.ToList();
        }
        public Equipment GetEquipment(int id)
        {
            return _rentalDbContext.Equipments.Find(id);
        }
    }
}
