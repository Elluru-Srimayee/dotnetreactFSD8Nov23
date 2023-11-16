using HotelBookingApi.Contexts;
using HotelBookingApi.Interfaces;
using HotelBookingApi.Models;

namespace HotelBookingApi.Repositories
{
        public class HotelRepository : IRepository<int,Hotel>
        {
            private readonly HotelDbContext _context;

            public HotelRepository(HotelDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public Hotel GetById(int id)
            {
                return _context.Hotels.Find(id);
            }

            public IList<Hotel> GetAll()
            {
                return _context.Hotels.ToList();
            }

            public Hotel Add(Hotel entity)
            {
                _context.Hotels.Add(entity);
                _context.SaveChanges();
                return entity;
            }

            public Hotel Update(Hotel entity)
            {
                _context.Hotels.Update(entity);
                _context.SaveChanges();
                return entity;
            }

            public Hotel Delete(int id)
            {
                var hotel = _context.Hotels.Find(id);
                if (hotel != null)
                {
                    _context.Hotels.Remove(hotel);
                    _context.SaveChanges();
                }
                return hotel;
            }
        }
 }