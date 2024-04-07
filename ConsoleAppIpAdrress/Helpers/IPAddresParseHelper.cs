using System.Net;

namespace ConsoleAppIpAdrress.Helpers
{
    public static class IPAddresParseHelper
    {
        public static IPAddress Parse(string ipAddressString, string parameterToDisplayWhenError)
        {
            if (!IPAddress.TryParse(ipAddressString, out IPAddress ipAddress))
            {
                throw new ArgumentException($"{parameterToDisplayWhenError} - непарвильный ip адрес");
            }
            return ipAddress;
        }
    }
}
