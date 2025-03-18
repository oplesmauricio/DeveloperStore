using System.ComponentModel.DataAnnotations;

namespace SalesApi.Application.Commands.Products
{
    public class SaleItemDto : IValidatableObject
    {
        [Required(ErrorMessage = "The product id is required!")]
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UnitPrice == 0)
            {
                yield return new ValidationResult(
                    $"The product {ProductId} with zero price",
                    new[] { nameof(UnitPrice) }
                );
            }

            if (TotalPrice == 0)
            {
                yield return new ValidationResult(
                    $"The product {ProductId} with zero total price",
                    new[] { nameof(TotalPrice) }
                );
            }

            if (Quantity == 0)
            {
                yield return new ValidationResult(
                    $"The product {ProductId} with zero quantity",
                    new[] { nameof(Quantity) }
                );
            }
        }
    }
}
