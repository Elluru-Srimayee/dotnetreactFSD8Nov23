using HotelBookingApi.Interfaces;
using HotelBookingApi.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public ActionResult Register([FromBody]UserDTO viewModel)
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
        public ActionResult Login([FromBody]UserDTO viewModel)
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
