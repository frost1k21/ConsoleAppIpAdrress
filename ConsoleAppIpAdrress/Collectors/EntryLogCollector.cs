using ConsoleAppIpAdrress.Models;
using System.Net;

namespace ConsoleAppIpAdrress.Collectors
{
    internal class EntryLogCollector
    {
        public Dictionary<IPAddress, int> LogDictionary { get; set; } = new();
        public void AddData(LogEntry logEntry)
        {
            if (!LogDictionary.ContainsKey(logEntry.IPAddress))
            {
                LogDictionary[logEntry.IPAddress] = 1;
            }
            else
            {
                LogDictionary[logEntry.IPAddress] += 1;
            }
        }
    }
}
