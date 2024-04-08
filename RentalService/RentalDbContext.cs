
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
            base.OnModelCreating(modelBuilder);
        }

      //  public void Add(Equipment equipment)
        //{
          //  throw new NotImplementedException();
        //}
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        
    }
}
