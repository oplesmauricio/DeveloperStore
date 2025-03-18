using MediatR;
using SalesApi.Domain.Entities;

namespace SalesApi.Domain.Notifications.Sales
{
    public class CreatedSaleNotification : INotification
    {
        public Sale Sale { get; set; }
    }
}
