using HotelBookingApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelBookingApi.Services;
using HotelBookingApi.Models.DTOs;
using HotelBookingApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace HotelBookingApi.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [Authorize]
        [HttpGet("{hotelId}")]
        public IActionResult GetRooms(int hotelId)
        {
            var rooms = _roomService.GetAllRooms(hotelId);
            return Ok(rooms);
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            var room = _roomService.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateRoom([FromBody] Room room)
        {
            var updatedRoom = _roomService.UpdateRoom(room);

            if (updatedRoom == null)
            {
                return NotFound();
            }

            return Ok(updatedRoom);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var deletedRoom = _roomService.DeleteRoom(id);

            if (deletedRoom == null)
            {
                return NotFound();
            }

            return Ok(deletedRoom);
        }
    }

}
