using System.ComponentModel.DataAnnotations;

namespace gT_UndergroundAPI.Data
{
    public class RegistrationRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}

        [Required(ErrorMessage = "Username is required.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? PasswordConfirmation { get; set; }
    }
}
