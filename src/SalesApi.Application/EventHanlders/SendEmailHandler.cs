using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SalesApi.Domain.Notifications;

namespace SalesApi.Application.EventHanlders
{
    public class SendEmailHandler : INotificationHandler<ProductCreatedNotification>
    {
        public async Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Email sent for product {notification.Product.Title}");
            await Task.CompletedTask;
        }
    }
}
