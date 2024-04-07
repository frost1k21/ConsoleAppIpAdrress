using ConsoleAppIpAdrress.Helpers;
using ConsoleAppIpAdrress.Models;

namespace ConsoleAppIpAdrress.ArgsParses
{
    public class SettingFromFileParser
    {
        public LogEntryOptions PopulateOtherParameters(LogEntryOptions logEntryOptions, SettingsFromFile settingsFromFile) 
        {
            if (string.IsNullOrEmpty(logEntryOptions.LogPath) &&
                !string.IsNullOrEmpty(settingsFromFile.LogPath))
            {
                logEntryOptions.LogPath = FileExistsHelper.Parse(settingsFromFile.LogPath, "LogPath из appsetting.json");
            }

            if (string.IsNullOrEmpty(logEntryOptions.OutputFilePath) &&
                !string.IsNullOrEmpty(settingsFromFile.OutputPath))
            {
                logEntryOptions.OutputFilePath = settingsFromFile.OutputPath;
            }

            if (DateTime.MinValue == logEntryOptions.DateStart &&
                !string.IsNullOrEmpty(settingsFromFile.StartDate))
            {
                logEntryOptions.DateStart = DateParseHelper.Parse(settingsFromFile.StartDate, "StartDate из appsetting.json");
            }

            if (DateTime.MinValue == logEntryOptions.DateEnd &&
                !string.IsNullOrEmpty(settingsFromFile.EndDate))
            {
                logEntryOptions.DateEnd = DateParseHelper.Parse(settingsFromFile.EndDate, "EndDate из appsetting.json");
            }

            if (logEntryOptions.AddressStart is null &&
                !string.IsNullOrEmpty(settingsFromFile.AddressStart))
            {
                logEntryOptions.AddressStart = IPAddresParseHelper.Parse(settingsFromFile.AddressStart, "AddressStart из appsetting.json");
            }

            if (logEntryOptions.AddressMask == 0 &&
                logEntryOptions.AddressStart is not null &&
                !string.IsNullOrEmpty(settingsFromFile.AddressMask))
            {
                logEntryOptions.AddressMask = IPAddressMaskParseHelper.Parse(settingsFromFile.AddressMask, "AddressMask из appsetting.json");
            }

            return logEntryOptions;
        }
    }
}
