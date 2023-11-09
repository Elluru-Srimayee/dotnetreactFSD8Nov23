using Shopping_App.Models.DTOs;

namespace Shopping_App.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
