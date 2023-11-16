namespace HotelBookingApi.Models.DTOs
{
    public class ReservationDto
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
