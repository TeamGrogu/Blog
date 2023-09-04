using System.ComponentModel.DataAnnotations;

namespace Blog.Validations
{
    public class UpperCase : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            string input = value.ToString();

            return input.Any(char.IsUpper);
        }
    }
}
