namespace ConsoleAppIpAdrress.Helpers
{
    public static class FileExistsHelper
    {
        public static string Parse(string filePath, string parameterToDisplayWhenError)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"{parameterToDisplayWhenError} - нет файла {filePath}");
            }
            return filePath;
        }
    }
}
