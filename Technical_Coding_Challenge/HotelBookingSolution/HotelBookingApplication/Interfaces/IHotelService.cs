using HotelBookingApi.Models;
using HotelBookingApi.Models.DTOs;

namespace HotelBookingApi.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetHotels(string city);
        HotelDTO AddHotel(HotelDTO hotelDTO);
        HotelDTO UpdateHotel(int id, HotelDTO hotelDTO);
        bool RemoveHotel(int id);
    }
}
