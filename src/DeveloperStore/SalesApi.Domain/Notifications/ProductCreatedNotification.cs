using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SalesApi.Domain.Entities;

namespace SalesApi.Domain.Notifications
{
    public class ProductCreatedNotification : INotification
    {
        public Product Product { get; set; }
    }
}
