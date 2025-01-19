using System.ComponentModel.DataAnnotations;

namespace CollageApp.Validator
{
    public class DateCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = (DateTime?)value;

            if(date < DateTime.Now)
            {
                return new ValidationResult("The datamusht be greater than ot equal to tdays date");
            }

            return ValidationResult.Success;
        }
    }
}
