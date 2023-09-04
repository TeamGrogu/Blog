using Blog.Services;
using System.ComponentModel.DataAnnotations;

namespace Blog.Validations
{
    public class EmailCheck:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success; // Let the Required attribute handle null values

            string email = value.ToString();
            var userService = (IUserService)validationContext.GetService(typeof(IUserService)); // Replace with your user service interface

            if (userService.IsEmailInUse(email))
            {
                return new ValidationResult(ErrorMessage ?? "Email is already in use.");
            }

            return ValidationResult.Success;
        }
    }
}
