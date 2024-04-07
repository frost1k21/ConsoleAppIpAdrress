using ConsoleAppIpAdrress.Helpers;
using ConsoleAppIpAdrress.Models;

namespace ConsoleAppIpAdrress.Validators
{
    internal class IPAddressEntryLogValidator : ILogEntryValidator
    {
        public bool Validate(LogEntry logEntry, LogEntryOptions entryOptions)
        {
            if (entryOptions.AddressStart is not null &&
                NetworkHelper.IsInMaskAndAboveIPAddress(logEntry, entryOptions.AddressStart, entryOptions.AddressMask))
            {
                return true;
            }
            return false;
        }
    }
}
