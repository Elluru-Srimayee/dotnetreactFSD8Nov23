﻿using HotelBookingApi.Contexts;
using HotelBookingApi.Interfaces;
using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Repositories
{
    public class HotelRepository : IRepository<int, Hotel>
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context)
        {
            _context = context;
        }
        public Hotel Add(Hotel entity)
        {
            _context.Hotels.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Hotel Delete(int key)
        {
            var hotel = GetById(key);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                _context.SaveChanges();
                return hotel;
            }
            return null;
        }

        public IList<Hotel> GetAll()
        {
            if (_context.Hotels.Count() == 0)
                return null;
            return _context.Hotels.ToList();
        }

        public Hotel GetById(int key)
        {
            var hotel = _context.Hotels.SingleOrDefault(u => u.HotelId == key);
            return hotel;
        }

        public Hotel Update(Hotel entity)
        {
            var hotel = GetById(entity.HotelId);
            if (hotel != null)
            {
                _context.Entry<Hotel>(hotel).State = EntityState.Modified;
                _context.SaveChanges();
                return hotel;
            }
            return null;
        }
    }
}
