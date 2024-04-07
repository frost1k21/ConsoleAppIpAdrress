using System.Net;

namespace ConsoleAppIpAdrress.Models
{
    public class LogEntry
    {
        public IPAddress IPAddress { get; set; }
        public DateTime EntryDate { get; set; }
    }
}