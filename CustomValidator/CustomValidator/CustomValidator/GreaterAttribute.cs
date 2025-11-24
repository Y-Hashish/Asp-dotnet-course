using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CustomValidator.CustomValidator
{
    public class GreaterAttribute : ValidationAttribute
    {
        public string otherPropertyName { get; set; }
        public GreaterAttribute(string prop)
        {
            otherPropertyName = prop;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime d1 = Convert.ToDateTime(value);

                PropertyInfo? otherProperty  = validationContext.ObjectType.GetProperty(otherPropertyName);
                if(otherProperty != null)
                {
                    DateTime other = Convert.
                        ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));
                    if(other > d1)
                    {
                        return new ValidationResult(ErrorMessage,
                            new string[] { otherPropertyName, validationContext.MemberName });
                    }
                    else return ValidationResult.Success;
                }
            }
            return null;    
        }
    }
}
