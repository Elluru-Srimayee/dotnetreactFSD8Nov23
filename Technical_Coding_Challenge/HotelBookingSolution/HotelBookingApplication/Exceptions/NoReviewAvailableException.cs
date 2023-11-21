using System.Runtime.Serialization;

namespace HotelBookingApi.Exceptions
{
    public class NoReviewAvailableException : Exception
    {
        string message;
        public NoReviewAvailableException()
        {
            message = "No reviews are available for display";
        }
        public override string Message => message;
    }
}