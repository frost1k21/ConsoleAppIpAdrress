namespace ConsoleAppIpAdrress.Helpers
{
    public static class DateParseHelper
    {
        public static DateTime Parse(string dateString, string parameterToDisplayWhenError)
        {
            if (!DateTime.TryParse(dateString, out DateTime date))
            {
                throw new ArgumentException($"{parameterToDisplayWhenError} - неверный формат даты");
            }
            return date;
        }
    }
}
