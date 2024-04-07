namespace ConsoleAppIpAdrress.IO
{
    internal class FileLogReader
    {
        public IAsyncEnumerable<string> GetLogData(string logFilePath)
        {
            return File.ReadLinesAsync(logFilePath);
        }
    }
}
