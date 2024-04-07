using ConsoleAppIpAdrress.Collectors;
using ConsoleAppIpAdrress.Models;
using ConsoleAppIpAdrress.Validators;
using System.Net;

namespace ConsoleAppIpAdrress.Processors
{
    internal class DataProcessor
    {
        private readonly EntryLogCollector entryLogCollector;
        private readonly LogEntryOptions entryOptions;
        private readonly ILogEntryValidator ipAddressValidator;
        private readonly ILogEntryValidator dateValidator;

        public DataProcessor(EntryLogCollector entryLogCollector,
            LogEntryOptions entryOptions
            )
        {
            this.entryLogCollector = entryLogCollector;
            this.entryOptions = entryOptions;
            ipAddressValidator = new IPAddressEntryLogValidator();
            dateValidator = new DateEntryLogValidator();
        }

        public async Task<Dictionary<IPAddress, int>> ProcessData(IAsyncEnumerable<string> dataLines)
        {
            await foreach (var logLine in dataLines)
            {
                var data = logLine.Split(':', 2);
                var logEntry = new LogEntry
                {
                    IPAddress = IPAddress.Parse(data[0]),
                    EntryDate = DateTime.Parse(data[1]),
                };

                if (ipAddressValidator.Validate(logEntry, entryOptions) &&
                    dateValidator.Validate(logEntry, entryOptions))
                {
                    entryLogCollector.AddData(logEntry);
                }
            }

            return entryLogCollector.LogDictionary;
        }
    }
}
