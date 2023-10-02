

using Microsoft.EntityFrameworkCore;
using RentCarApi.Entities.Vehicles.BaseEntities;
using RentCarApi.Entities.Vehicles.TechnicalInformation;

namespace RentCarApi.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Vehicles

            modelBuilder.Entity<Vehicle>().HasOne(a => a.Mark).WithMany(e => e.Vehicles).HasForeignKey(x => x.MarkId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Vehicle>().HasOne(a => a.Model).WithMany(e => e.Vehicles).HasForeignKey(x => x.ModelId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Vehicle>().HasOne(a => a.VehicleLocation).WithMany(e => e.Vehicles).HasForeignKey(x => x.VehicleLocationId).OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region VehiclesTechnicalInformation
            modelBuilder.Entity<Model>().HasOne(a => a.Mark).WithMany(e => e.Models).HasForeignKey(x => x.MarkId).OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
