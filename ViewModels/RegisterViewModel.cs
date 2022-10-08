using System.ComponentModel.DataAnnotations;

namespace Assignment_12_1.ViewModels
{
    public class RegisterViewModel:LoginViewModel
    {
        [Required(ErrorMessage ="Enter first name")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Enter last name")]
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
