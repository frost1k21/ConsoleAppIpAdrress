namespace ConsoleAppIpAdrress.Helpers
{
    public static class IPAddressMaskParseHelper
    {
        public static int Parse(string intString, string parameterToDisplayWhenError)
        {
            if (!int.TryParse(intString, out int mask))
            {
                throw new ArgumentException($"{parameterToDisplayWhenError} - должно быть десятичным числом");
            }
            if (mask < 0 || mask > 32)
            {
                throw new ArgumentException($"{parameterToDisplayWhenError} - может быть межу 0 и 32");
            }
            return mask;
        }
    }
}
