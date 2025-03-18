using MediatR;
using SalesApi.Domain.Entities;

namespace SalesApi.Domain.Notifications.Products
{
    public class CreatedProductNotification : INotification
    {
        public Product Product { get; set; }
    }
}
