using System.ComponentModel.DataAnnotations;

namespace CustomValidator.CustomValidator
{
    public class AssignmentGreaterAttribute: ValidationAttribute
    {
        public int minYear { get; set; } = 2000;
        public string errir { get; set; } = "the year should be greater than 2000-01-01";
        public AssignmentGreaterAttribute()
        {
            
        }
        public AssignmentGreaterAttribute(int year)
        {
            minYear = year;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (Convert.ToDateTime(value).Year < minYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? errir, minYear));
                }else 
                    return ValidationResult.Success;
            }
            return null;
        }
    }

}
