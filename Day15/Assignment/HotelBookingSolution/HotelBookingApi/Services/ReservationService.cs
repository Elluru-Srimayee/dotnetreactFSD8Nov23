using HotelBookingApi.Contexts;
using HotelBookingApi.Interfaces;
using HotelBookingApi.Models;

namespace HotelBookingApi.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HotelDbContext _context;

        public ReservationService(HotelDbContext context)
        {
            _context = context;
        }

        public Reservation GetReservationById(int reservationId)
        {
            return _context.Reservations.Find(reservationId);
        }

        public IEnumerable<Reservation> GetReservationsByUserId(string username)
        {
            return _context.Reservations.Where(res => res.Username.Equals(username)).ToList();
        }

        public void AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        public void UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
        }

        public void DeleteReservation(int reservationId)
        {
            var reservation = _context.Reservations.Find(reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
        }
    }

}
