using ConsoleAppIpAdrress.Helpers;

namespace ConsoleAppIpAdrress.Tests.Helpers
{
    public class IPAddressMaskParseHelperTest
    {
        [Fact]
        public void ThorwError_WhenIPAddressMaskNotInRange()
        {
            var maskWithError = "45";
            var parameterForErrorMessage = "--address-mask";
            var errorMessage = $"{parameterForErrorMessage} - может быть межу 0 и 32";

            var ex = Assert.Throws<ArgumentException>(() => IPAddressMaskParseHelper.Parse(maskWithError, parameterForErrorMessage));
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}
