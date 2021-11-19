namespace Playground.Microservices.API.Settings
{
    public class AppSettings
    {
        public DatabaseConnection ConnectionStrings { get; set; }

        public LoggingConnection LoggingStrings { get; set; }

        public PollyCiruit Polly { get; set; }
    }
}
