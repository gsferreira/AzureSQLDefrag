using System;
using Microsoft.Extensions.Logging;


namespace AzureSQLDefrag.Tests.Logging
{
    public class Logger : AzureSQLDefrag.Logging.ILogger
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public Logger()
        {
            var LoggerFactory = new LoggerFactory()
                .AddConsole()
                .AddDebug();

            _logger = LoggerFactory.CreateLogger(nameof(DefragServiceTests));
        }

        void AzureSQLDefrag.Logging.ILogger.Debug(string message)
        {
            _logger.LogDebug(message);
        }

        void AzureSQLDefrag.Logging.ILogger.Error(string message)
        {
            _logger.LogError(message);
        }


        void AzureSQLDefrag.Logging.ILogger.Information(string message)
        {
            _logger.LogInformation(message);
        }

        void AzureSQLDefrag.Logging.ILogger.Warning(string message)
        {
            _logger.LogWarning(message);
        }
    }
}
