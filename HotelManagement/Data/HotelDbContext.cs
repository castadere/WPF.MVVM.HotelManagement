using HotelManagement.Data.EntityConfigurations;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data
{
    public class HotelDbContext : DbContext
    {
        #region DbSets

        public DbSet<RoomModel> Rooms { get; set; }

        public DbSet<ReservationModel> Reservations { get; set; }

        public DbSet<HotelModel> Hotels { get; set; }

        #endregion

        #region Public methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=hotelmanagement.db");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoomModelConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
