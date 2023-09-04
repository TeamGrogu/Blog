using System.ComponentModel.DataAnnotations;

namespace Blog.Validations
{
    public class DateCheck:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime <= DateTime.Now;
            }
            return true;
        }
    }
}
