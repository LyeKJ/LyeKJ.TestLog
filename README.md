# LyeKJ.TestLog
This library is intended to ease unit testing on ```ILogger``` of ```Microsoft.Extensions.Logging```.
When using ```ILogger```, for example:
```csharp
public class Example
{
    private readonly ILogger<Example> logger;

    public Example(ILogger<Example> logger)
    {
        this.logger = logger;

        using (this.logger.BeginScope("scope 1"))
        {
            this.logger.LogInformation("object created");
        }
    }
}
```
We can easily test it using ```TestLogger``` of this library:
```csharp
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
```
This makes checking the logging behaviors easy when comparing to verifying the ```void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)``` method of ```ILogger``` using mocking libraries.
