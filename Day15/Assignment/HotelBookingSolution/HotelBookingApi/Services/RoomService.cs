using HotelBookingApi.Contexts;
using HotelBookingApi.Interfaces;
using HotelBookingApi.Models;

namespace HotelBookingApi.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<int, Room> _roomRepository;
        public RoomService(IRepository<int, Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }
        private readonly HotelDbContext _context;

        public RoomService(HotelDbContext context)
        {
            _context = context;
        }

        public Room GetRoomById(int roomId)
        {
            return _context.Rooms.Find(roomId);
        }

        public IList<Room> GetAllRooms(int hotelId)
        {
            return _context.Rooms.Where(r => r.HotelId == hotelId).ToList();
        }

        public Room AddRoom(Room room)
        {
            if (room != null)
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();
            }
            return null;
        }

        public Room UpdateRoom(Room room)
        {
            if (room != null)
            {
                _context.Rooms.Update(room);
                _context.SaveChanges();
            }
            return null;
        }

        public Room DeleteRoom(int roomId)
        {
            if (roomId != null) { 
                var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }
            return null;
        }
    }

}
