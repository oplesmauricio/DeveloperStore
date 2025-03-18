using MediatR;

namespace SalesApi.Domain.Notifications.Sales
{
    public class CancelledSaleNotification : INotification
    {
        public int SaleId { get; set; }
    }
}
