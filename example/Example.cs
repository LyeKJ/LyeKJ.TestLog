using Microsoft.Extensions.Logging;

namespace LyeKJ.TestLog.Example
{
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
}