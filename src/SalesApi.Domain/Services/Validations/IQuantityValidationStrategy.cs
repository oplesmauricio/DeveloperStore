namespace SalesApi.Domain.Services.Validations
{
    public interface IQuantityValidationStrategy
    {
        bool IsValid(int quantity);
        string GetErrorMessage();
    }

}
