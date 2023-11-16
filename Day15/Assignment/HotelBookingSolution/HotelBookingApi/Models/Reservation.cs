using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        // Additional reservation details, status, etc.

        public int Username { get; set; }
        public User User { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }

}
