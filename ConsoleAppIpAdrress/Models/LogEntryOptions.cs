using System.Net;

namespace ConsoleAppIpAdrress.Models
{
    public class LogEntryOptions
    {
        public string LogPath { get; set; }
        public string OutputFilePath { get; set; }
        public IPAddress? AddressStart { get; set; }
        public int AddressMask { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}