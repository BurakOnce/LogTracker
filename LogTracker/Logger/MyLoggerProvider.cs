using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace LogTracker.Logger
{
    public class MyLoggerProvider : ILoggerProvider
    {
        private bool disposedValue;

        public MyLoggerProvider()
        {
        }

        ILogger ILoggerProvider.CreateLogger(string categoryName)
        {
            return new MyLogger();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }


        void System.IDisposable.Dispose()
        {
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }

    public class MyLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string msgLog= formatter(state,exception);
            msgLog = $"{DateTime.Now:U} - {msgLog}";
            Debug.WriteLine(msgLog);
        }
    }
}
