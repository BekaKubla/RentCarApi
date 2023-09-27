

using Microsoft.EntityFrameworkCore;
using RentCarApi.Entities.Vehicles.BaseEntities;

namespace RentCarApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Vehicles

            modelBuilder.Entity<Vehicle>().HasOne(a => a.Mark).WithMany(e => e.Vehicles).HasForeignKey(x => x.MarkId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Vehicle>().HasOne(a => a.Model).WithMany(e => e.Vehicles).HasForeignKey(x => x.ModelId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Vehicle>().HasOne(a => a.VehicleLocation).WithMany(e => e.Vehicles).HasForeignKey(x => x.VehicleLocationId).OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}
