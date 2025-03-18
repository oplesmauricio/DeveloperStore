namespace SalesApi.Domain.Services
{
    public class TenPercentDiscountStrategy : IDiscountStrategy
    {
        public bool IsApplicable(int quantity) => quantity >= 4 && quantity < 10;
        public decimal CalculateDiscount(int quantity, decimal unitPrice) => quantity * unitPrice * 0.10m;
    }
}
