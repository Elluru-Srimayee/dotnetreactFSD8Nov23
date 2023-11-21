using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Models.DTOs
{
    public class UserRegisterDTO : UserDTO
    {
        // Gets retype password for verification as required field
        [Required(ErrorMessage = "Re type password cannot be empty")]
        [Compare("Password", ErrorMessage = "Password and retype password do not match")]
        public string ReTypePassword { get; set; }
        // Gets name as required field
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        //Gets Phone as required field
        [Required(ErrorMessage = "Phone cannot be empty")]
        public string Phone { get; set; }
        // Gets address as required field
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }

    }
}
