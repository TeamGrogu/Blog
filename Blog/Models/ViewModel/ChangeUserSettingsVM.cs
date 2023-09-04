using Blog.Validations;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModel
{
    public class ChangeUserSettingsVM
    {
        public string? Password { get; set; }
        public string? OldPassword { get; set; }
        public IFormFile? UserImage { get; set; }
    }
}
