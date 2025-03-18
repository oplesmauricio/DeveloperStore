using FluentResults;
using SalesApi.Domain.Services;
using SalesApi.Domain.Services.Validations;

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
