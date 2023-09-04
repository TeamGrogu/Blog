using Blog.Validations;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModel
{
    public class LoginVM
    {
        [Required]
        [StringLength(16, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [SpecialCharacter(ErrorMessage = "The field must contain at least one special character.")]
        [UpperCase(ErrorMessage = "The field must contain at least one uppercase letter.")]
        [Number(ErrorMessage = "The field must contain at least one number.")]
        public string Password { get; set; }
        [Required]
        [EmailCheck(ErrorMessage = "Email is already in use.")]
        public string Email { get; set; }
    }
}
