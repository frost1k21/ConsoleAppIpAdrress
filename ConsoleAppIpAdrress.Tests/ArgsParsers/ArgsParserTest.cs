using ConsoleAppIpAdrress.ArgsParses;

namespace ConsoleAppIpAdrress.Tests.ArgsParsers
{
    public class ArgsParserTest
    {
        [Fact]
        public void ThrowError_WhenLastParameterIsEmpty() 
        {
            var argumets = new[]
            {
                "dll path",
                "--address-start",
            };

            var sut = new ArgsParser();

            var ex = Assert.Throws<ArgumentException>(() => sut.Parse(argumets));
            Assert.Equal("параметр не может быть пустым", ex.Message);
        }

        [Fact]
        public void Throw_WhenParamaterInvalid()
        {
            var argumets = new[]
            {
                "dll path",
                "--ivalid-parameter",
                "test"
            };

            var sut = new ArgsParser();
            var ex = Assert.Throws<ArgumentException>(() => sut.Parse(argumets));
            Assert.Equal("непрвельный параметр --ivalid-parameter", ex.Message);
        }


        [Fact]
        public void ThowError_WhenIPAddressMaskParameter_UseWithoutIPAddressParameter()
        {
            var argumets = new[]
            {
                "dll path",
                "--address-mask",
                "21"
            };

            var sut = new ArgsParser();
            var ex = Assert.Throws<ArgumentException>(() => sut.Parse(argumets));
            Assert.Equal("нельзя использовать параметр --address-mask без --address-start", ex.Message);
        }
    }
}
