using HotelBookingApi.Interfaces;
using HotelBookingApi.Models.DTOs;
using HotelBookingApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly ILogger<UserController> _logger;

        public ReservationController(IReservationService reservationService, ILogger<UserController> logger)
        {
            _reservationService = reservationService;
            _logger = logger;
        }
        /// <summary>
        /// Add the reservation details
        /// </summary>
        /// <param name="ReservationDTO">Details of reservation to be added</param>
        /// <returns>The booking details</returns>
        [HttpPost("addReservation")]
        [Authorize(Roles = "User")]
        public ActionResult AddReservation(ReservationDTO reservationDTO)
        {
            var reservation = _reservationService.AddReservationDetails(reservationDTO);
            if (reservation != null)
            {
                _logger.LogInformation("reservation done successfully");
                return Ok(reservation);
            }
           _logger.LogError("Could not reserve rooms");
            return BadRequest("Could not reserve");
        }
        /// <summary>
        /// Retrieve the reservation of hotel
        /// </summary>
        /// <param name="id">id of hotel to retrieve</param>
        /// <returns>All the booking details of a hotel</returns>
        [HttpGet("adminReservation")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAdminReservation(int id)
        {
            var reservation = _reservationService.GetReservation(id);
            if(reservation != null)
            {
                _logger.LogInformation("Admin Reservation details displayed");
                return Ok(reservation);
            }
            _logger.LogError("Could not display admin Reservations");
            return BadRequest("No Reservation found");
        }
        /// <summary>
        /// Retrieve the user Reservation
        /// </summary>
        /// <param name="id">id of a user</param>
        /// <returns>Reservation dteails of a user</returns>
        [HttpGet("userReservation")]
        [Authorize(Roles = "User")]
        public ActionResult GetUserReservation(string id)
        {
            var reservation = _reservationService.GetUserReservation(id);
            if (reservation != null)
            {
                _logger.LogInformation("User Reservation details displayed");
                return Ok(reservation);
            }
            _logger.LogError("Could not display user Reservations");
            return BadRequest("No Reservations found");
        }
        /// <summary>
        /// Update the status of booking
        /// </summary>
        /// <param name="id">Reservation id</param>
        /// <param name="status">Current status of Reservation</param>
        /// <returns>the updated status</returns>
        [HttpPost("Update")]
        public ActionResult UpdateReservation(int id,string status)
        {
            var reservation = _reservationService.UpdateReservationStatus(id,status);
            if (reservation != null)
            {
                _logger.LogInformation("Reservation status updated");
                return Ok(reservation);
            }
            _logger.LogError("Could not update reservation status");
            return BadRequest("couldn't update");
        }
    }
}
