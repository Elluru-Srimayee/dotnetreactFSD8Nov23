using System.Runtime.Serialization;

namespace HotelBookingApi.Exceptions
{
    [Serializable]
    public class NoReservationAvailableException : Exception
    {
        string message;
        public NoReservationAvailableException()
        {
            message = "No Reservation available to display";
        }
        public override string Message => message;
    }
}