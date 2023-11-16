using HotelBookingApi.Contexts;
using HotelBookingApi.Interfaces;
using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Services
{
    public class HotelService : IHotelService
    {
        private readonly HotelDbContext _context;

        private readonly IRepository<int, Hotel> _hotelRepository;

        public HotelService(IRepository<int, Hotel> repository)
        {
            _hotelRepository = repository;
        }
        public HotelService(HotelDbContext context)
        {
            _context = context;
        }
        Hotel IHotelService.GetHotelById(int hotelId)
        {
            return _context.Hotels.Find(hotelId);
        }

        IList<Hotel> IHotelService.GetAllHotels()
        {
            return _context.Hotels.ToList();
        }

        Hotel IHotelService.AddHotel(Hotel hotel)
        {
            var result = _hotelRepository.Add(hotel);
            return result;
        }

        public Hotel UpdateHotel(int id, Hotel hotel)
        {
            if (hotel != null)
            {
                _context.Hotels.Update(hotel);
                _context.SaveChanges();
            }
            return null;
        }

        public Hotel DeleteHotel(int hotelId)
        {
            if (hotelId != null)
            {
                var hotel = _context.Hotels.Find(hotelId);
                if (hotel != null)
                {
                    _context.Hotels.Remove(hotel);
                    _context.SaveChanges();
                }
            }
            return null;
        }
    }
}
