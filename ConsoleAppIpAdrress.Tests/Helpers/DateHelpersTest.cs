using ConsoleAppIpAdrress.Helpers;
using ConsoleAppIpAdrress.Models;

namespace ConsoleAppIpAdrress.Tests.Helpers
{
    public class DateHelpersTest
    {
        private static readonly DateTime _startTime = DateTime.Parse("06.04.2024");
        private static readonly DateTime _endTime = DateTime.Parse("07.04.2024").AddDays(1).AddMilliseconds(-1);

        [Theory]
        [MemberData(nameof(GetData))]
        public void CheckEntryDateInSpecificRange(LogEntry logEntry, bool expectation)
        {
            var result = DateHelpers.IsInRangeDate(logEntry, _startTime, _endTime);
            Assert.Equal(expectation, result);
        }


        public static IEnumerable<object[]> GetData() =>
            new[]
            {
                new object[]
                {
                    new LogEntry()
                    {
                        EntryDate = DateTime.Parse("2024-04-06 12:25:01")
                    },
                    true
                },
                new object[]
                {
                    new LogEntry()
                    {
                        EntryDate = DateTime.Parse("2024-04-06 00:00:00")
                    },
                    true
                },
                new object[]
                {
                    new LogEntry()
                    {
                        EntryDate = DateTime.Parse("2024-04-07 23:59:59")
                    },
                    true
                },
                new object[]
                {
                    new LogEntry()
                    {
                        EntryDate = DateTime.Parse("2024-04-05 12:25:01")
                    },
                    false
                },
                new object[]
                {
                    new LogEntry()
                    {
                        EntryDate = DateTime.Parse("2024-04-08 12:25:01")
                    },
                    false
                }
            };
    }
}
