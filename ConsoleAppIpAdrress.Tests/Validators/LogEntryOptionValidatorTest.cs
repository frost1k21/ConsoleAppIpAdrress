using ConsoleAppIpAdrress.Models;
using ConsoleAppIpAdrress.Validators;

namespace ConsoleAppIpAdrress.Tests.Validators
{
    public class LogEntryOptionValidatorTest
    {
        private readonly LogEntryOptionValidator _validator = new();


        [Theory]
        [MemberData(nameof(GetData))]
        public void ThrowError_WhenOneOrAllRequiredParametersIsNotSet(LogEntryOptions options)
        {
            var ex = Assert.Throws<ArgumentException>(() => _validator.ValidateLogEntryOptions(options));
            Assert.Equal("не установленны обязательные параметры", ex.Message);
        }

        [Fact]
        public void ThrowError_WhenStartDateGreaterThanEndDate()
        {
            var options = new LogEntryOptions
            {
                LogPath = "test",
                OutputFilePath = "test",
                DateStart = DateTime.Parse("07.04.2024"),
                DateEnd = DateTime.Parse("06.04.2024"),
            };

            var ex = Assert.Throws<ArgumentException>(() => _validator.ValidateLogEntryOptions(options));
            Assert.Equal("начальная дата не может быть больше конечной", ex.Message);
        }

        public static IEnumerable<object[]> GetData() =>
            new[]
            {
                new object[]
                {
                    new LogEntryOptions(),
                },
                new object[]
                {
                    new LogEntryOptions()
                    {
                        OutputFilePath = "test",
                    },
                },
                new object[]
                {
                    new LogEntryOptions()
                    {
                        LogPath = "test",
                        OutputFilePath = "test",
                    },
                },
                new object[]
                {
                    new LogEntryOptions()
                    {
                        LogPath = "test",
                        OutputFilePath = "test",
                        DateEnd = DateTime.Now
                    },
                },
            };
    }
}
