using ConsoleAppIpAdrress.Helpers;
using ConsoleAppIpAdrress.Models;

namespace ConsoleAppIpAdrress.Validators
{
    internal class DateEntryLogValidator : ILogEntryValidator
    {
        public bool Validate(LogEntry logEntry, LogEntryOptions entryOptions)
        {
            return DateHelpers.IsInRangeDate(logEntry, entryOptions.DateStart, entryOptions.DateEnd);
        }
    }
}
