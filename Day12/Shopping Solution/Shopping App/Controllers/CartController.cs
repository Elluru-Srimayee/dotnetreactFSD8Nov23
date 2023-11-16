using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping_App.Interfaces;
using Shopping_App.Models.DTOs;
namespace Shopping_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [Authorize(Roles ="Admin")]
        [HttpPost("add")]
        public IActionResult AddToCart(CartDTO cartDTO)
        {
            var result = _cartService.AddToCart(cartDTO);
            if (result)
                return Ok(cartDTO);
            return BadRequest("Could not add item to cart");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Remove")]
        public IActionResult RemoveFromCart(CartDTO cartDTO)
        {
            var result = _cartService.RemoveFromCart(cartDTO);
            if (result)
                return Ok("Deleted Item Successfully");
            return BadRequest("Could not remove the item from cart");
        }
    }
}
