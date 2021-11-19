namespace Playground.Microservices.API.Services
{
    using System;

    public class DateTimeService : IDateTimeService
    {
        public DateTime GetDateTime() => DateTime.Now;

        public DateTime GetDateTime(double days) => DateTime.Now.AddDays(days);

        public DateTimeOffset GetNow() => DateTimeOffset.Now;

        public DateTimeOffset GetNow(double days) => DateTimeOffset.Now.AddDays(days);

        public DateTimeOffset GetUtcNow() => DateTimeOffset.UtcNow;

        public DateTimeOffset GetUtcNow(double days) => DateTimeOffset.UtcNow.AddDays(days);
    }
}
