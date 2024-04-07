using ConsoleAppIpAdrress.Models;
using System.Text.Json;

namespace ConsoleAppIpAdrress.IO
{
    public class ParametersFromFileReader
    {
        public SettingsFromFile GetSettingsFromFile()
        {
            var settingsPath = Path.Combine(Environment.CurrentDirectory, "appsettings.json");
            try
            {
                var text = File.ReadAllText(settingsPath);
                var settings = JsonSerializer.Deserialize<SettingsFromFile>(text);
                return settings;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
