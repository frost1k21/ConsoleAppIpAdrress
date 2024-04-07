using ConsoleAppIpAdrress.Models;
using System.Net;

namespace ConsoleAppIpAdrress.Helpers
{
    public static class NetworkHelper
    {
        public static bool IsInMaskAndAboveIPAddress(LogEntry logEntry, IPAddress startAddress, int networkMask)
        {
            var maskAddressBits = BitConverter.ToUInt32(startAddress.GetAddressBytes().Reverse().ToArray(), 0);
            var ipAddressBits = BitConverter.ToUInt32(logEntry.IPAddress.GetAddressBytes().Reverse().ToArray(), 0);
            uint mask = uint.MaxValue << 32 - networkMask;

            return maskAddressBits <= ipAddressBits && (maskAddressBits & mask) == (ipAddressBits & mask);
        }
    }
}