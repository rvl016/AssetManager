using System;
using Microsoft.Extensions.Logging;


namespace AssetManager.Shared
{

    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }

    public class ConsoleLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Information:
                case LogLevel.None:
                    return false;
                case LogLevel.Debug:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                default:
                    return true;
            }
        }

        public void Log<TState>(
            LogLevel logLevel, EventId eventId, TState state, 
            Exception exception, Func<TState, Exception, string> formatter
        ) {
            Console.Write($"[{logLevel}] - {eventId.Id}:");
            
            if (state != null) {
                Console.Write($" State: {state}");
            }

            if (exception != null) {
                Console.Write($" Exception: {exception.Message}");
            }

            Console.WriteLine();
        }
    }
}