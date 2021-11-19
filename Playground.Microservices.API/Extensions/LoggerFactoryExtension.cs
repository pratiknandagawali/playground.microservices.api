namespace Playground.Microservices.API.Extensions
{
    using System;
    using Microsoft.Extensions.Logging;

    public static class LoggerFactoryExtension
    {
        public static ILoggerFactory CreateAndLog(
            this ILoggerFactory loggerFactory,
            string drivePath,
            string applicationName)
        {
            var date = DateTime.Today.ToShortDateString();

            var logfile = $"{drivePath}\\{applicationName}-{date}.txt";

            loggerFactory.CreateAndLog(logfile, applicationName);

            return loggerFactory;
        }
    }
}
