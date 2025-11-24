using System.ComponentModel.DataAnnotations;
using CustomValidator.CustomValidator;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace CustomValidator.Models
{
    public class Person : IValidatableObject
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        public DateTime? Date1 { get; set; }

        [Greater("Date1", ErrorMessage = "{0} should be smaller than {1}")]

        public DateTime? Date2 { get; set; }

        
        public int? age { get; set; }
        public List<string?> tags { get; set; } = new List<string?>();
        public DateTime? dateOfBirth { get; set; }
        public override string ToString()
        {
            return $"id :{Id}, Name :{Name}, Date1 :{Date1}, Date2 :{Date2}\ntags : {string.Join("\n",tags)} ";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(age.HasValue == false && dateOfBirth.HasValue ==  false)
            {
                yield return new ValidationResult("enter either age or date of birth");
            }
        }
    }
}
