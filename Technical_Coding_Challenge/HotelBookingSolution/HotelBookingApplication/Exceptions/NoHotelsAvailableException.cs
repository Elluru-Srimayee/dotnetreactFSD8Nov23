using System.Runtime.Serialization;

namespace HotelBookingApi.Exceptions
{
    public class NoHotelsAvailableException : Exception
    {
        string message;
        public NoHotelsAvailableException()
        {
            message = "No hotels are available for display";
        }
        public override string Message => message;
    }
}