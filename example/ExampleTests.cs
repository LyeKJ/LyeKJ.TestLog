using System.Linq;
using Microsoft.Extensions.Logging;
using Xunit;

namespace LyeKJ.TestLog.Example
{
    public class ExampleTests
    {
        [Fact]
        public void ShouldLogInfo()
        {
            var testLogger = new TestLogger<Example>();

            var example = new Example(testLogger);

            Assert.Equal(LogLevel.Information, testLogger.Logs.ElementAt(0).LogLevel);
            Assert.Equal("object created", testLogger.Logs.ElementAt(0).Message);
            Assert.Null(testLogger.Logs.ElementAt(0).Exception);

            Assert.Equal("scope 1", testLogger.Scopes.ElementAt(0).ScopeState);
            Assert.True(testLogger.Scopes.ElementAt(0).IsDisposed);
        }
    }
}