using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Application.Interfaces;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Services
{
    public class EventLogger : IEventLogger
    {
        public void Log(string eventType)
        {
            Console.WriteLine($"Event: {eventType}");
        }
    }
}
