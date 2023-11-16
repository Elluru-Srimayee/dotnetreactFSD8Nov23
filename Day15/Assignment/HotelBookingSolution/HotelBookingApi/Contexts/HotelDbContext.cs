using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Contexts
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between Hotel and Room
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if a hotel is deleted, delete its rooms too

            // Configure one-to-many relationship between User and Reservation
             // Cascade delete if a user is deleted, delete their reservations too

            // Configure one-to-many relationship between Room and Reservation
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Reservations)
                .WithOne(res => res.Room)
                .HasForeignKey(res => res.RoomId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if a room is deleted, delete its reservations too

            base.OnModelCreating(modelBuilder);
        }
    }

}
