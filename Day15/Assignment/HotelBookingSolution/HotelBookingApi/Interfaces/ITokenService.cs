using HotelBookingApi.Models.DTOs;

namespace HotelBookingApi.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
