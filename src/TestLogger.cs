using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace LyeKJ.TestLog
{
    public class TestLogger : ILogger, ITestLogger
    {
        private const LogLevel DefaultLogLevel = LogLevel.Trace;

        private IList<Log> logEntries;

        private IList<TestLoggerScope> scopes;

        private LogLevel minimumLogLevel;

        public TestLogger() : this(DefaultLogLevel)
        {
        }

        public TestLogger(LogLevel minimumLogLevel)
        {
            logEntries = new List<Log>();
            scopes = new List<TestLoggerScope>();
            this.minimumLogLevel = minimumLogLevel;
        }

        public IReadOnlyCollection<Log> Logs { get => new ReadOnlyCollection<Log>(logEntries); }

        public IReadOnlyCollection<TestLoggerScope> Scopes { get => new ReadOnlyCollection<TestLoggerScope>(scopes); }

        public IDisposable BeginScope<TState>(TState state)
        {
            var scope = new TestLoggerScope(state);
            scopes.Add(scope);
            return scope;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return minimumLogLevel <= logLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                logEntries.Add(new Log(formatter(state, exception), logLevel, exception));
            }
        }

        public IList<string> GetMessages(LogLevel logLevel)
        {
            return logEntries.Where(x => x.LogLevel == logLevel).Select(x => x.Message).ToList();
        }
    }
}
