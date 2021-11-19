namespace Playground.Microservices.API.Infrastructure
{
    public interface IConfigurationReader<Type>
    {
        Type GetValue(string path);
    }
}
