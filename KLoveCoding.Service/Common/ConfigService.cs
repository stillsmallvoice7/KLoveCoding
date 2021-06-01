using Microsoft.Extensions.Configuration;
using System.IO;

namespace KLoveCoding.Service.Common
{
    public static class ConfigService
    {
        private static IConfiguration configuration;
        static ConfigService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }

        public static string Get(string name)
        {
            string appSettings = configuration[name];
            return appSettings;
        }
    }
}
