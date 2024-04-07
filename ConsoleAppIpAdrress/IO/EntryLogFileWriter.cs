using System.Net;
using System.Text;

namespace ConsoleAppIpAdrress.IO
{
    internal class EntryLogFileWriter
    {
        public void FileWrite(Dictionary<IPAddress, int> data, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var logEntry in data)
            {
                sb.AppendLine($"{logEntry.Key} - {logEntry.Value}");
            }
            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}
