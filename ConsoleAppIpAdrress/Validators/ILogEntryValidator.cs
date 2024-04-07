using ConsoleAppIpAdrress.Models;

namespace ConsoleAppIpAdrress.Validators
{
    internal interface ILogEntryValidator
    {
        public bool Validate(LogEntry logEntry, LogEntryOptions entryOptions);
    }
}
