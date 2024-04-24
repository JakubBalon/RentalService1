
using RentalService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RentalService.Models.ViewModels;

namespace RentalService
{
    public class RentalDbContext : IdentityDbContext<User>
    {
        public RentalDbContext(DbContextOptions options) : base(options) { }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SetRental>(eb =>
            {

                eb.HasMany(w => w.RentedEquipments)
                .WithOne(c => c.SetRental)
                .HasForeignKey(w => w.Id);

            });

            modelBuilder.Entity<User>(eb =>
            {
                eb.HasMany(w => w.SetRentals)
                .WithOne(c => c.User)
                .HasForeignKey(w => w.SetRentalId);
            });

            modelBuilder.Entity<Rental>(eb =>
            {
                eb.HasOne(w => w.RentedEquipment);
                
                
                
            });


            base.OnModelCreating(modelBuilder); 
        }

      //  public void Add(Equipment equipment)
        //{
          //  throw new NotImplementedException();
        //}
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public DbSet<SetRental> SetRentals { get; set;}

        
    }
}
