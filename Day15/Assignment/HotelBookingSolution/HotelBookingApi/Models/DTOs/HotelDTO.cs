namespace HotelBookingApi.Models.DTOs
{
        public class HotelDTO
        {
            public string Name { get; set; }
            public string Location { get; set; }
            public decimal PricePerNight { get; set; }
            public int StarRating { get; set; }
            public string Description { get; set; }
        }
}
