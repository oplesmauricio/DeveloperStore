using System.Runtime.CompilerServices;
using System.Text.Json;
using SalesApi.Application.Interfaces;

namespace SalesApi.Application.Services
{
    public class EventLogger : IEventLogger
    {
        public void Log(string msg)
        {
            Console.WriteLine($"Msg: {msg}");
        }

        public void Log(Exception ex, [CallerMemberName] string name = "")
        {
            Console.WriteLine($"Method: {name}\n {JsonSerializer.Serialize(ex)}");
        }
    }
}
