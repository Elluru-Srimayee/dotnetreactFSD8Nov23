using HotelBookingApi.Contexts;
using HotelBookingApi.Interfaces;
using HotelBookingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingApi.Repositories
{
    public class RoomRepository : IRepository<int, Room>
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Room GetById(int id)
        {
            return _context.Rooms.Find(id);
        }

        public IList<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public Room Add(Room entity)
        {
            _context.Rooms.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Room Update(Room entity)
        {
            _context.Rooms.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public Room Delete(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
            return room;
        }
    }
}
