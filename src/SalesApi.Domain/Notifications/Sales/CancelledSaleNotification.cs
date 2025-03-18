using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SalesApi.Domain.Entities;

namespace SalesApi.Domain.Notifications.Sales
{
    public class CancelledSaleNotification : INotification
    {
        public int SaleId { get; set; }
    }
}
