using SalesApi.Application.Interfaces;

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
