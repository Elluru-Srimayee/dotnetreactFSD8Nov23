using HotelBookingApi.Models;
using HotelBookingApi.Models.DTOs;

namespace HotelBookingApi.Interfaces
{
    public interface IRoomService
    {
        Room GetRoomById(int roomId);
        IList<Room> GetAllRooms(int hotelId);
        Room AddRoom(Room room);
        Room UpdateRoom(Room room);
        Room DeleteRoom(int roomId);

    }
}
