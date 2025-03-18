using MediatR;
using SalesApi.Domain.Notifications.Sales;

namespace SalesApi.Application.EventHanlders
{
    public class CancelledSaleNotificationHandler : INotificationHandler<CancelledSaleNotification>
    {
        public async Task Handle(CancelledSaleNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Cancelled sale {notification.SaleId}");
            await Task.CompletedTask;
        }
    }
}
