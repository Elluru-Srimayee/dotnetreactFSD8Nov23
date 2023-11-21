using HotelBookingApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApi.Models
{
    public class Reservation
    {
        /// Gets or sets the unique identifier for the booking.
        [Key]
        public int ReservationId { get; set; }

        /// Gets or sets the unique identifier for the user making the booking.
        /// </summary>
        public String UserId { get; set; }

        /// <summary>
        /// Gets or sets the associated User object for the booking user.
        /// </summary>
        [ForeignKey("UserId")]
        public User user { get; set; }

        /// <summary>
        /// Gets or sets the booking date.
        /// </summary>
        public string ReservationDate { get; set; }

        /// <summary>
        /// Gets or sets the check in date
        /// </summary>
        public string CheckIn { get; set; }

        /// <summary>
        /// Gets or sets the check out
        /// </summary>
        public string CheckOut { get; set; }

        /// Gets or sets the unique identifier for the booked room.
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room room { get; set; }

        /// <summary>
        /// Gets or sets the status of the booking
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the total number of booked
        /// </summary>
        public int TotalRoom { get; set; }

        /// <summary>
        /// Gets or sets the total price for the booking
        /// </summary>
        public float Price { get; set; }
    }

}