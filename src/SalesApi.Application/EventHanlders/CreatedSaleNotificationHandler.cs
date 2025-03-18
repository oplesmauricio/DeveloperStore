using MediatR;
using SalesApi.Domain.Notifications.Sales;

namespace SalesApi.Application.EventHanlders
{
    public class CreatedSaleNotificationHandler : INotificationHandler<CreatedSaleNotification>
    {
        public async Task Handle(CreatedSaleNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Created sale {notification.Sale.SaleNumber}");
            await Task.CompletedTask;
        }
    }
}
