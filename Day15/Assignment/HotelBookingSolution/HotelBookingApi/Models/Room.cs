using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        // Other room details
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public List<Reservation> Reservations { get; set; }

        // Additional room details, features, etc.
    }

}
