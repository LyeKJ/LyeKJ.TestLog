using System;

namespace LyeKJ.TestLog
{
    public class TestLoggerScope : IDisposable
    {
        internal TestLoggerScope(object scopeState)
        {
            ScopeState = scopeState;
        }

        public object ScopeState { get; }

        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }
}