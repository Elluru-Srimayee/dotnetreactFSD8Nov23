using HotelBookingApi.Contexts;
using HotelBookingApi.Interfaces;
using HotelBookingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingApi.Repositories
{
    public class ReservationRepository : IRepository<int, Reservation>
    {
        private readonly HotelDbContext _context;

        public ReservationRepository(HotelDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Reservation GetById(int id)
        {
            return _context.Reservations.Find(id);
        }

        public IList<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public Reservation Add(Reservation entity)
        {
            _context.Reservations.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Reservation Update(Reservation entity)
        {
            _context.Reservations.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public Reservation Delete(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
            return reservation;
        }
    }
}
