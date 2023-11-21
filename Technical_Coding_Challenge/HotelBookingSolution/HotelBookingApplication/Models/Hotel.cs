using HotelBookingApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApi.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        // Gets or sets the user identifier associated with the hotel
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }

        // Gets or sets the hotel name
        public string HotelName { get; set; }

        /// Gets or sets city where hotel is located
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the address of the hotel
        /// </summary>
        public string Address { get; set; }

        /// Gets or sets the phone number of the hotel
        public string Phone { get; set; }

        /// Gets or sets the description of the hotel
        public string Description { get; set; }
        /// Gets or sets the starting price of the hotel
        public float StartingPrice { get; set; } = 0;
    }
}
