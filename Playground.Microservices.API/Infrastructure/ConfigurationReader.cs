namespace Playground.Microservices.API.Infrastructure
{
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;

    public class ConfigurationReader<Type> : IConfigurationReader<Type>
    {
        private readonly IConfiguration configuration;

        public ConfigurationReader(IConfiguration configuration) => 
            this.configuration = configuration;

        public Type GetValue(string path)
        {
            var configurationValue = this.configuration.GetValue<Type>(path);

            if(configurationValue == null)
            {
                throw new KeyNotFoundException(nameof(path));
            }
            return configurationValue;
        }
    }
}
