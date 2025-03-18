
using System.Runtime.CompilerServices;

namespace SalesApi.Application.Interfaces
{
    public interface IEventLogger
    {
        void Log(string msg);
        void Log(Exception ex, [CallerMemberName] string name = "");
    }
}
