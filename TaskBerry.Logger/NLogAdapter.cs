using System;
using System.IO;
using NLog;

namespace TaskBerry.Logger
{
    public class NLogAdapter : Infrastructure.Contracts.Services.ILogger
    {
        private readonly NLog.Logger _logger;

        public NLogAdapter()
        {
            _logger = LogManager.LoadConfiguration(Properties.Settings.Default.DefaultLoggerConfigFile).GetCurrentClassLogger();
        }

        public NLogAdapter(string configFile)
        {
            if(File.Exists(configFile))
                _logger = LogManager.LoadConfiguration(configFile).GetCurrentClassLogger();
            else
                _logger = LogManager.LoadConfiguration(Properties.Settings.Default.DefaultLoggerConfigFile).GetCurrentClassLogger();
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogDebug(string message, Exception ex)
        {
            _logger.Debug(ex, message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogError(string message, Exception ex)
        {
            _logger.Error(ex, message);
        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public void LogInfo(string message, Exception ex)
        {
            _logger.Info(ex, message);
        }
    }
}
