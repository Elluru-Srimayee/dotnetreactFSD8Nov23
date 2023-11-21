using HotelBookingApi.Models;
using HotelBookingApi.Models.DTOs;

namespace HotelBookingApi.Interfaces
{
    public interface IRoomService
    {
        List<Room> GetRooms(int hotelid,string checkIn, string checkOut);
        RoomDTO AddRoom(RoomDTO room);
        RoomDTO UpdateRoom(int id, RoomDTO room);
        bool RemoveRoom(int id);
    }
}
