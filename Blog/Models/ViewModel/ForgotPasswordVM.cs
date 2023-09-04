using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModel
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
