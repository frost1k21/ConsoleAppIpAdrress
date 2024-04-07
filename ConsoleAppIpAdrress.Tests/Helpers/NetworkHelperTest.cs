using ConsoleAppIpAdrress.Helpers;
using ConsoleAppIpAdrress.Models;
using System.Net;

namespace ConsoleAppIpAdrress.Tests.Helpers
{
    public class NetworkHelperTest
    {
        private static readonly IPAddress _addressStart = IPAddress.Parse("192.168.3.7");
        private static readonly int _addressMask = 21;

        [Theory]
        [MemberData(nameof(GetData))]
        public void CheckIfLogEntryIPAddresAboveAndInMask(LogEntry logEntry, bool expectation)
        {
            var result = NetworkHelper.IsInMaskAndAboveIPAddress(logEntry, _addressStart, _addressMask);
            Assert.Equal(expectation, result);
        }

        public static IEnumerable<object[]> GetData() =>
            new[]
            {
                new object[]
                {
                    new LogEntry()
                    {
                        IPAddress = IPAddress.Parse("192.168.1.1"),
                    },
                    false
                },
                new object[]
                {
                    new LogEntry()
                    {
                        IPAddress = IPAddress.Parse("192.168.3.2"),
                    },
                    false
                },
                new object[]
                {
                    new LogEntry()
                    {
                        IPAddress = IPAddress.Parse("192.168.3.7"),
                    },
                    true
                },
                new object[]
                {
                    new LogEntry()
                    {
                        IPAddress = IPAddress.Parse("192.168.4.6"),
                    },
                    true
                },
                new object[]
                {
                    new LogEntry()
                    {
                        IPAddress = IPAddress.Parse("192.168.5.1"),
                    },
                    true
                }
            };
    }
}
