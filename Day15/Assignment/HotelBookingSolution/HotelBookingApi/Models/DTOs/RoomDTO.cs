namespace HotelBookingApi.Models.DTOs
{
    public class RoomDTO
    {
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public string RoomType { get; set; }
    }
}
