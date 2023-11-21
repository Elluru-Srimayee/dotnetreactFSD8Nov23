using HotelBookingApi.Contexts;
using HotelBookingApi.Interfaces;
using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Repositories
{
    public class RoomFacilitiesRespsitory : IRepository<int, RoomFacilities>
    {
        private readonly HotelDbContext _context;

        public RoomFacilitiesRespsitory(HotelDbContext context)
        {
            _context = context;
        }
        public RoomFacilities Add(RoomFacilities entity)
        {
            _context.RoomFacilities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public RoomFacilities Delete(int key)
        {
            var amenity = GetById(key);
            if (amenity != null)
            {
                _context.RoomFacilities.Remove(amenity);
                _context.SaveChanges();
                return amenity;
            }
            return null;
        }

        public IList<RoomFacilities> GetAll()
        {
            if(_context.RoomFacilities.Count() == 0)
                return null;
            return _context.RoomFacilities.ToList();
        }

        public RoomFacilities GetById(int key)
        {
            var Facility = _context.RoomFacilities.SingleOrDefault(u => u.RoomFacilityId == key);
            return Facility;
        }

        public RoomFacilities Update(RoomFacilities entity)
        {
            var Facility = GetById(entity.RoomFacilityId);
            if (Facility != null)
            {
                _context.Entry<RoomFacilities>(Facility).State = EntityState.Modified;
                _context.SaveChanges();
                return Facility;
            }
            return null;
        }
    }
}
