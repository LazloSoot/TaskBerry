using System;

namespace TaskBerry.Infrastructure.Contracts.Services
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogInfo(string message, Exception ex);

        void LogDebug(string message);
        void LogDebug(string message, Exception ex);

        void LogError(string message);
        void LogError(string message, Exception ex);

        void Shutdown();
    }
}
