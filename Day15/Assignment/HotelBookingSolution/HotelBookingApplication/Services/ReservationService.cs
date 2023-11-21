using HotelBookingApi.Exceptions;
using HotelBookingApi.Interfaces;
using HotelBookingApi.Models;
using HotelBookingApi.Models.DTOs;
using HotelBookingApi.Repositories;
using System.Net.Mail;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace HotelBookingApi.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<int, Reservation> _reservationRepository;
        private readonly IRepository<int, Room> _roomRepository;
        private readonly IRepository<int, Hotel> _hotelRepository;
        private readonly IRepository<string, User> _userRepository;

        public ReservationService(IRepository<int, Reservation> reservationRepository,IRepository<int,Room> roomRepository, IRepository<int , Hotel> hotelRepository, IRepository<string, User> userRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Adds the booking details based on the provided bookingDTO
        /// </summary>
        /// <param name="reservationDTO">BookingDTO contains details of booking</param>
        /// <returns>returns the bookingDTo if the booking was succesfully added; otherwise returns a null value</returns>
        public ReservationDTO AddReservationDetails(ReservationDTO reservationDTO)
        {

            // Retrieve the room id based on the roomId from bookingDTO
            int roomId = reservationDTO.RoomId;
            var room = _roomRepository.GetById(roomId);
            var hotel = _hotelRepository.GetById(room.HotelId);

            //Calculate the amount for booking based on the price of the room and total number of room
            float amount = (reservationDTO.TotalRoom * room.Price);
            DateTime dateTime = DateTime.Now;

            //Create a new booking object with the details from bookingDTO
            Reservation reservation = new Reservation()
            {
                UserId = reservationDTO.UserId,
                CheckIn = reservationDTO.CheckIn,
                CheckOut = reservationDTO.CheckOut,
                RoomId = reservationDTO.RoomId,
                TotalRoom = reservationDTO.TotalRoom,
                Status = "Booked",
                ReservationDate = dateTime.ToString(),
                Price = amount
          
            };
            //Add the new reservation to the repository
            var result = _reservationRepository.Add(reservation);
            var user = _userRepository.GetById(reservationDTO.UserId);
            string message = $"Dear {user.Name},\nThank you for choosing {hotel.HotelName}! Your reservation is confirmed, and we are thrilled to welcome you for your upcoming stay. Your booking reference number is {result.ReservationId}. \nSafe travels!\nBest regards,\nThe {hotel.HotelName} Team\n{hotel.Phone}";
            string subject = $"Booking Confirmation - {hotel.HotelName}";
            string body = $"Dear Sir/Mam,\nThank you for choosing {hotel.HotelName}! Your reservation is confirmed, and we are thrilled to welcome you for your upcoming stay.\nBooking Details:-\nBooking ID: {result.ReservationId}\nCheck-In Date: {result.CheckIn}\nCheck-Out Date: {result.CheckOut}\nRoom Type: {room.RoomType}\nTotal Price: {amount}\n\n\nWe look forward to making your stay at {hotel.HotelName} a memorable experience. Safe travels!\nBest regards,\nThe {hotel.HotelName} Team\n{hotel.Phone}";

            //Check if the booking was added successfully and return the bookingDTO
            if (result != null)
            {
                  return reservationDTO;
            }
            //Returns null if booking was not added successfully
            return null;
        }
        
        /// <summary>
        /// Retrieve a list of booking object based on the unique hotel identifier
        /// </summary>
        /// <param name="hotelId">The unique identifier of a hotel</param>
        /// <returns>Returns the list of booking object for the provided hotel; Otherwise return null</returns>
        public List<Reservation> GetReservation(int hotelId)
        {
            //use LINQ to join booking and room entities based on room id and filtered by hotel id and project the result into new booking
            var reservations = (from Reservation in _reservationRepository.GetAll()
                            join room in _roomRepository.GetAll() on Reservation.RoomId equals room.RoomId
                            where room.HotelId == hotelId
                            select new Reservation
                            {
                                ReservationId = Reservation.ReservationId,
                                ReservationDate = Reservation.ReservationDate,
                                CheckIn = Reservation.CheckIn,
                                CheckOut = Reservation.CheckOut,
                                RoomId = Reservation.RoomId,
                                Status = Reservation.Status,
                                TotalRoom = Reservation.TotalRoom,
                                Price = Reservation.Price ,
                                UserId = Reservation.UserId
                            })
                    .ToList();

            //Check if the reservation was found  and return the reservation list; Otherwise return null
            if (reservations.Count > 0)
            {
                return reservations;
            }
            return null;
        }

        /// <summary>
        /// Retrieve the list of reservation details based on the unique id of a user
        /// </summary>
        /// <param name="userId">Unique id of a user</param>
        /// <returns>Returns the list of reservation object from the provided user id</returns>
        /// <exception cref="NoBookingsAvailableException">Thrown when no bookings are available for the specified user</exception>
        public List<Reservation> GetUserReservation(string userId)
        {
            //Retrieve the booking details for the specified user
            var user = _reservationRepository.GetAll().Where(u => u.UserId == userId).ToList();

            //Check if the booking was found and return the Reservation list; Otherwise thows a NoReservationAvailableException
            if (user != null)
            {
                return user;
            }
            throw new NoReservationAvailableException();
        }

        /// <summary>
        /// Updates the booking status based on the bookingId and status
        /// </summary>
        /// <param name="ReservationId">Unique identifier of booking to update</param>
        /// <param name="status">New status to set for the booking</param>
        /// <returns>Returns the updated booking; otherwise return null</returns>
        public Reservation UpdateReservationStatus(int bookingId, string status)
        {
            //Retrieve the booking with the specified bookingId from the repository
            var booking = _reservationRepository.GetById(bookingId);
            //Check if the booking is found
            if(booking != null)
            {
                // update the status of booking
                booking.Status = status;
                //update the status in the repository
                var result = _reservationRepository.Update(booking);
                //Returns the updated booking 
                return booking;
            }
            //Returns null if the Booking was found with the specified bookingId 
            return null;
        }
        
    }
}
