using System.ComponentModel.DataAnnotations;

namespace Shopping_App.Models.DTOs
{
    public class UserViewModel : UserDTO
    {
        [Required(ErrorMessage = "Confirm password cannot be empty")]
        [Compare("Password", ErrorMessage = "Password and Confirm password do not match")]
        public string ConfirmPassword { get; set; }

    }
}