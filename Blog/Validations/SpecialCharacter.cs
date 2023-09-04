using System.ComponentModel.DataAnnotations;

namespace Blog.Validations
{
    public class SpecialCharacter : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            string input = value.ToString();

            string specialCharacters = "!@#$%^&*()_+[]{}|;:'\",.<>?/";

            return input.Any(c => specialCharacters.Contains(c));
        }
    }
}
