using Shopping_App.Models.DTOs;

namespace Shopping_App.Interfaces
{
    public interface ICartService
    {
        bool AddToCart(CartDTO cartDTO);
        bool RemoveFromCart(CartDTO cartDTO);
    }
}
