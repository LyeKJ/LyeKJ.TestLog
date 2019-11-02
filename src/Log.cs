using System;
using Microsoft.Extensions.Logging;

namespace LyeKJ.TestLog
{
    public class Log
    {
        public Log(string message, LogLevel logLevel, Exception exception)
        {
            Message = message;
            LogLevel = logLevel;
            Exception = exception;
        }

        public string Message { get; }

        public LogLevel LogLevel { get; }

        public Exception Exception { get; }
    }
}