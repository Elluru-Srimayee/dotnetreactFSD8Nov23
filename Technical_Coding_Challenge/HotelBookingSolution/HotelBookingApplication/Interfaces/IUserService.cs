using HotelBookingApi.Models.DTOs;

namespace HotelBookingApi.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserRegisterDTO userRegisterDTO);
    }
}
