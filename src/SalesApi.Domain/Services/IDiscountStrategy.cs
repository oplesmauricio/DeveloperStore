namespace SalesApi.Domain.Services
{
    public interface IDiscountStrategy
    {
        bool IsApplicable(int quantity);
        decimal CalculateDiscount(int quantity, decimal unitPrice);
    }
}
