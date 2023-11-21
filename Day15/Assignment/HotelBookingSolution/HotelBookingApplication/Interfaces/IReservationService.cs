using HotelBookingApi.Models;
using HotelBookingApi.Models.DTOs;

namespace HotelBookingApi.Interfaces
{
    public interface IReservationService
    {
        public ReservationDTO AddReservationDetails(ReservationDTO bookingDTO);
        public Reservation UpdateReservationStatus(int bookingId, string status);
        public List<Reservation> GetUserReservation(string userId);

        public List<Reservation> GetReservation(int hotelId);
    }
}
