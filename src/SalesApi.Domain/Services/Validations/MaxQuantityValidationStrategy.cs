namespace SalesApi.Domain.Services.Validations
{
    public class MaxQuantityValidationStrategy : IQuantityValidationStrategy
    {
        private const int MaxQuantity = 20;

        public bool IsValid(int quantity)
        {
            return quantity <= MaxQuantity;
        }

        public string GetErrorMessage()
        {
            return $"You cannot buy more than 20 pieces of the same item";
        }
    }

}
