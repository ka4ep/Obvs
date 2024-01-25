using System;

namespace Obvs.Logging.Serilog
{
    public class SerilogLoggerWrapper : ILogger
    {
        private readonly global::Serilog.ILogger _logger;

        public SerilogLoggerWrapper(global::Serilog.ILogger logger)
        {
            _logger = logger;
        }
        public void Debug(string message, Exception exception = null)
        {
            if (exception == null)
                _logger.Debug(message);
            else
                _logger.Debug(message, exception);
        }

        public void Info(string message, Exception exception = null)
        {
            if (exception == null)
                _logger.Information(message);
            else
                _logger.Information(message, exception);
        }

        public void Warn(string message, Exception exception = null)
        {
            if (exception == null)
                _logger.Warning(message);
            else
                _logger.Warning(message, exception);
        }
        public void Error(string message, Exception exception = null)
        {
            if (exception == null)
                _logger.Error(message);
            else
                _logger.Error(message, exception);
        }
        public void Log(LogLevel level, string message, Exception exception = null)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    Debug(message, exception);
                    break;
                case LogLevel.Info:
                    Info(message, exception);
                    break;
                case LogLevel.Warn:
                    Warn(message, exception);
                    break;
                case LogLevel.Error:
                    Error(message, exception);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }
    }
}
