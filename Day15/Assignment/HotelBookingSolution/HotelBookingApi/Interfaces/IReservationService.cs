using HotelBookingApi.Models;

namespace HotelBookingApi.Interfaces
{
    public interface IReservationService
    {
        Reservation GetReservationById(int reservationId);
        IEnumerable<Reservation> GetReservationsByUserId(string username);
        void AddReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(int reservationId);
    }

}
