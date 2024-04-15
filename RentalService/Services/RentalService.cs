using RentalService.Interfaces;
using RentalService.Models;

namespace RentalService.Services.Interfaces
{


    public class RentalService : IRentalService
    {
        private readonly RentalDbContext _rentalDbContext;

        public RentalService(RentalDbContext rentalDbContext)
        {
            _rentalDbContext = rentalDbContext;
        }
        public List<Rental> GetRentals(string userid)
        {

            return _rentalDbContext.Rentals.Where(x => x.User.Id == userid).ToList();
        }
        public Rental GetRental(int id)
        {


            return _rentalDbContext.Rentals.FirstOrDefault(x => x.RentalId == id);

        }



        public void CreateRental(IFormCollection form)
        {
            var rentedEquipment = form["Equipment"].ToString();
            var user = _rentalDbContext.Users.FirstOrDefault(x => x.Id == form["UserId"].ToString());
            var newrental = new Rental(form, _rentalDbContext.Equipments.FirstOrDefault(x => x.EquipmentName == rentedEquipment), user);
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
            updatedRental.EditRental(form, equipment, user);
            _rentalDbContext.Entry(updatedRental).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _rentalDbContext.SaveChanges();

        }
        public void DeleteRental(int id)
        {
            var rental = _rentalDbContext.Rentals.Find(id);
            _rentalDbContext.Rentals.Remove(rental);
            _rentalDbContext.SaveChanges();
        }

        public List<Equipment> GetEquipments(string userid)
        {
            return _rentalDbContext.Equipments.Where(x => x.User.Id == userid).ToList();
        }
        public Equipment GetEquipment(int id)
        {
            return _rentalDbContext.Equipments.Find(id);
        }
    }
}
