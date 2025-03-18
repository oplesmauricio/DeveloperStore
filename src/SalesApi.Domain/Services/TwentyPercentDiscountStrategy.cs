namespace SalesApi.Domain.Services
{
    public class TwentyPercentDiscountStrategy : IDiscountStrategy
    {
        public bool IsApplicable(int quantity) => quantity >= 10 && quantity <= 20;
        public decimal CalculateDiscount(int quantity, decimal unitPrice) => quantity * unitPrice * 0.20m;
    }
}
