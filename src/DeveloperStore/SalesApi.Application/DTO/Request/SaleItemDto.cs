using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Services;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace SalesApi.Application.DTO.Request
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
