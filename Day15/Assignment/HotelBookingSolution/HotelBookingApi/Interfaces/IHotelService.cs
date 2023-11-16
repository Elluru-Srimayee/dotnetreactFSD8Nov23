using HotelBookingApi.Models;
using HotelBookingApi.Models.DTOs;

namespace HotelBookingApi.Interfaces
{
    public interface IHotelService
    {
        Hotel GetHotelById(int hotelId);
        IList<Hotel> GetAllHotels();
        Hotel AddHotel(Hotel hotel);
        Hotel UpdateHotel(int id,Hotel hotel);
        Hotel DeleteHotel(int id);
    }

}
