using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApi.Models
{
    public class RoomFacilities
    {
  
        // Gets or sets the unique identifier of the amenity
        [Key]
        public int RoomFacilityId { get; set; }

        /// Gets or sets the unique room identifier associated with room amenity
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room room { get; set; }

        /// Gets or sets the amenities for the room
        public string Facilities { get; set; }
    }
}
