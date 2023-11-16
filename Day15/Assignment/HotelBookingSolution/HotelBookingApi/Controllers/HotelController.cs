using HotelBookingApi.Interfaces;
using HotelBookingApi.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using HotelBookingApi.Models;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/hotels")]
public class HotelController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }
    [Authorize]
    [HttpGet]
    public IActionResult GetHotels()
    {
        var hotels = _hotelService.GetAllHotels();
        return Ok(hotels);
    }
    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetHotelById(int id)
    {
        var hotel = _hotelService.GetHotelById(id);

        if (hotel == null)
        {
            return NotFound();
        }

        return Ok(hotel);
    }
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult AddHotel(Hotel hotel)
    {
         if(hotel!=null)
        {
            return (IActionResult)hotel;
        }
        return null;
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public IActionResult UpdateHotel(int id, [FromBody] Hotel hotel)
    {
        var updatedHotel = _hotelService.UpdateHotel(id, hotel);

        if (updatedHotel == null)
        {
            return NotFound();
        }

        return Ok(updatedHotel);
    }
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public IActionResult DeleteHotel(int id)
    {
        var deletedHotel = _hotelService.DeleteHotel(id);

        if (deletedHotel == null)
        {
            return NotFound();
        }

        return Ok(deletedHotel);
    }
}