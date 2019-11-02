using Microsoft.Extensions.Logging;

namespace LyeKJ.TestLog
{
    public class TestLogger<T> : TestLogger, ILogger<T>
    {
    }
}