
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalService.Models;

namespace RentalService
{
    public class RentalDbContext : IdentityDbContext<User>
    {
        public RentalDbContext(DbContextOptions options) : base(options) { }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            /*
                        modelBuilder.Entity<Rental>(r =>
                        {


                            r.HasMany(r => r.Equipments)
                            .WithMany(e => e.Rentals)
                            .UsingEntity<RentedEquipment>
                            (
                            e => e.HasOne(re => re.Rental)
                            .WithMany(r => r.Equipments)
                            .HasForeignKey(re => re.RentalId),

                            r => r.HasMany(r => r.Equipment)
                            .WithOne(e => e.Rentals)
                            .HasForeignKey(e => e.EquipmentId),

                            req => { req.HasKey(req => new { req.EquipmentId, req.RentalId }); }







                              );

            */

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
