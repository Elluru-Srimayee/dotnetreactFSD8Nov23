using HotelBookingApi.Interfaces;
using HotelBookingApi.Contexts;
using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Repositories
{
    public class ReservationRepository : IRepository<int, Reservation>
    {
        private readonly HotelDbContext _context;

        public ReservationRepository(HotelDbContext context)
        {
            _context = context;
        }
        public Reservation Add(Reservation entity)
        {
            _context.Reservations.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Reservation Delete(int key)
        {
            throw new NotImplementedException();
        }
 
        public IList<Reservation> GetAll()
        {
            if (_context.Reservations.Count() == 0)
                return null;

            return _context.Reservations.ToList();
        }

        public Reservation GetById(int key)
        {
            var reservation = _context.Reservations.SingleOrDefault(u => u.ReservationId == key);
            return reservation;
        }

        public Reservation Update(Reservation entity)
        {
            var reservation = GetById(entity.ReservationId);
            if (reservation != null)
            {
                _context.Entry<Reservation>(reservation).State = EntityState.Modified;
                _context.SaveChanges();
                return reservation;
            }
            return null;
        }
    }
}
