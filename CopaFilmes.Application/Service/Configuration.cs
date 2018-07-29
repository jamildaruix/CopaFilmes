using System.Configuration;

namespace CopaFilmes.Application.Service
{
    public class Configuration : IConfiguration
    {
        public string AppSettingsConfiguration(int index)
        {
            return ConfigurationManager.AppSettings[index];
        }

        public string AppSettingsConfiguration(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
