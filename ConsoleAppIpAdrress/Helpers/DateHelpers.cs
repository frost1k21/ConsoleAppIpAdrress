using ConsoleAppIpAdrress.Models;

namespace ConsoleAppIpAdrress.Helpers
{
    public static class DateHelpers
    {
        public static bool IsInRangeDate(LogEntry logEntry, DateTime start, DateTime end)
        {
            if (start > logEntry.EntryDate)
            {
                return false;
            }

            if (end < logEntry.EntryDate)
            {
                return false;
            }
            return true;
        }

    }
}