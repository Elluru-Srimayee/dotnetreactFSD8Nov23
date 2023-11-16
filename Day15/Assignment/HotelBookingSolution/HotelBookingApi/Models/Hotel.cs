using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        // Other hotel details
        public string Description { get; set; }
        public decimal PricePerNight { get; set; }

        public List<Room> Rooms { get; set; }

        // Additional hotel details, amenities, etc.
    }

}
