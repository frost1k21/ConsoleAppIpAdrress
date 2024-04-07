namespace ConsoleAppIpAdrress.Models
{
    public class SettingsFromFile
    {
        public string LogPath { get; set; } = string.Empty;
        public string OutputPath { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public string AddressStart { get; set; } = string.Empty;
        public string AddressMask { get; set; } = string.Empty;
    }
}
