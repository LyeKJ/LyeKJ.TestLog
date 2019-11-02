using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace LyeKJ.TestLog
{
    public interface ITestLogger
    {
        /// <summary>
        /// Gets the logs that have been written.
        /// </summary>
        /// <value>The collection of logs.</value>
        IReadOnlyCollection<Log> Logs { get; }

        /// <summary>
        /// Gets the scopes started by logger.
        /// </summary>
        /// <value>The collection of scopes.</value>
        IReadOnlyCollection<TestLoggerScope> Scopes { get; }

        /// <summary>
        /// Gets log messages by log level.
        /// </summary>
        /// <param name="logLevel">The specified log level.</param>
        /// <returns>The log messages for the specified log level.</returns>
        IList<string> GetMessages(LogLevel logLevel);
    }
}