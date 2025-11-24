using CustomValidator.CustomValidator;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CustomValidator.Models
{
    public class Order : IValidatableObject
    {
        [BindNever]
        public int OrderNo { get; set; }
        [AssignmentGreater]
        [Required]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage ="the incoice ")]
        public double InvoicePrice { get; set; }
        [Required(ErrorMessage = "the productssss ")]
        public List<Product> Products { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            double s = Products.Select(p=> new {p.Price , p.Quantity}).Sum(s=>s.Price *s.Quantity);

            if(InvoicePrice != s)
            {
                yield return new ValidationResult("the InVoice is not equel to the total price", new[] {nameof(InvoicePrice)} );
            }
        }
    }
}
