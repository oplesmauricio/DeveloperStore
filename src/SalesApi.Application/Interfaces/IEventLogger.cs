namespace SalesApi.Application.Interfaces
{
    public interface IEventLogger
    {
        void Log(string eventType);
    }
}
