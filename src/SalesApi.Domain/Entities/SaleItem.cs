using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Domain.Services;
using System.Text.Json.Serialization;
using SalesApi.Domain.Services.Validations;
using FluentResults;

namespace SalesApi.Domain.Entities
{
    public class SaleItem
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; private set; }
        public decimal TotalPrice => (UnitPrice * Quantity) - Discount;

        public void ApplyDiscount(IEnumerable<IDiscountStrategy> strategies)
        {
            foreach (var strategy in strategies)
            {
                if (strategy.IsApplicable(Quantity))
                {
                    Discount = strategy.CalculateDiscount(Quantity, UnitPrice);
                    break;
                }
            }
        }

        public Result QuantityValidation(IEnumerable<IQuantityValidationStrategy> strategies)
        {
            foreach (var strategy in strategies)
                if (!strategy.IsValid(Quantity))
                    return Result.Fail(strategy.GetErrorMessage());

            return Result.Ok();
        }
    }
}
