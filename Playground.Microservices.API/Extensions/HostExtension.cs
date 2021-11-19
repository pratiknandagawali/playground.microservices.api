namespace Playground.Microservices.API.Extensions
{
    using System;
    using Microsoft.Extensions.Hosting;

    public static class HostExtension
    {
        public static int LogAndRun(this IHost host, Action<IHost> beforeRun = null)
        {
            if (beforeRun != null)
            {
                beforeRun(host);
            }

            host.Run();
            return 0;
        }
    }
}
