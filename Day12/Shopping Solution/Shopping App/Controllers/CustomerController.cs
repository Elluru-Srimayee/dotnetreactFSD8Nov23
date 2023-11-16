using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_App.Interfaces;
using Shopping_App.Models.DTOs;
namespace Shopping_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;

        public CustomerController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public ActionResult Register(UserDTO viewModel)
        {
            string message = "";
            try
            {
                var user = _userService.Register(viewModel);
                if (user != null)
                {
                    return Ok(user);
                }
            }
            catch (DbUpdateException exp)
            {
                message = "Duplicate username";
            }
            catch (Exception)
            {

            }


            return BadRequest(message);
        }
        [HttpPost("login")]
        public ActionResult Login(UserDTO viewModel)
        {
            string message = "";
                var result = _userService.Login(viewModel);
                if (result != null)
                {
                    return Ok(result);
                }
            message = "Invalid username or password";
            return BadRequest(message);
        }
    }
}
