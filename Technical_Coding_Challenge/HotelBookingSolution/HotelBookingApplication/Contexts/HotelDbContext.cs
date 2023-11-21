using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelBookingApi.Contexts
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }
        /// <summary>
        /// Creates User table in database
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Creates Hotel table in database
        /// </summary>
        public DbSet<Hotel> Hotels { get; set; }
        /// <summary>
        /// Creates Room table in database
        /// </summary>
        public DbSet<Room> Rooms { get; set; }
       
        /// Creates Room Amenity table in database
        /// </summary>
        public DbSet<RoomFacilities> RoomFacilities { get; set; }
        /// <summary>
        /// Creates the Booking in the database
        /// </summary>
        public DbSet<Reservation> Reservations { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure the relationship between Hotels and Reviews
            
            modelBuilder.Entity<Reservation>()
            .HasOne(e => e.room)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        }
    }
 }
