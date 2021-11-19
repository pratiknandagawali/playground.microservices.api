namespace Playground.Microservices.API.Services
{
    using System;

    public interface IDateTimeService
    {
        DateTime GetDateTime();

        DateTimeOffset GetUtcNow();

        DateTimeOffset GetNow();

        DateTime GetDateTime(double days);

        DateTimeOffset GetUtcNow(double days);

        DateTimeOffset GetNow(double days);
    }
}
