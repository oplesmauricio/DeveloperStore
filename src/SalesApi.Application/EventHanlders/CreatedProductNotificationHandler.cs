using MediatR;
using SalesApi.Domain.Notifications.Products;

namespace SalesApi.Application.EventHanlders
{
    public class CreatedProductNotificationHandler : INotificationHandler<CreatedProductNotification>
    {
        public async Task Handle(CreatedProductNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Created product {notification.Product.Title}");
            await Task.CompletedTask;
        }
    }
}
