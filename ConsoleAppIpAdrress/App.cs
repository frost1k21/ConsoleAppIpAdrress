using ConsoleAppIpAdrress.ArgsParses;
using ConsoleAppIpAdrress.Collectors;
using ConsoleAppIpAdrress.IO;
using ConsoleAppIpAdrress.Models;
using ConsoleAppIpAdrress.Processors;
using ConsoleAppIpAdrress.Validators;

namespace ConsoleAppIpAdrress
{
    internal class App
    {
        public async Task Run()
        {
            try
            {
                PrintInfo();
                LogEntryOptions logEntryOptions = new();
                var logReader = new FileLogReader();
                var dataWriter = new EntryLogFileWriter();
                var logDictionary = new EntryLogCollector();
                
                var logEntryOptionsValidator = new LogEntryOptionValidator();

                var args = Environment.GetCommandLineArgs();
                if (args.Length > 1)
                {
                    var parser = new ArgsParser();
                    logEntryOptions = parser.Parse(args);
                }

                var validLogEntryOptions = logEntryOptionsValidator.ValidateLogEntryOptions(logEntryOptions);

                var dataProcessor = new DataProcessor(logDictionary, validLogEntryOptions);

                var logLines = logReader.GetLogData(validLogEntryOptions.LogPath);
                var resultDictionary = await dataProcessor.ProcessData(logLines);

                dataWriter.FileWrite(resultDictionary, validLogEntryOptions.OutputFilePath);
                Console.WriteLine("результат был записан в файл:");
                Console.WriteLine(validLogEntryOptions.OutputFilePath);
                PrintEndMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine("произошла ошибка");
                Console.WriteLine(ex.Message);
                PrintEndMessage();
            }
        }

        private void PrintEndMessage()
        {
            Console.WriteLine();
            Console.Write("Для выхода из приложения нажмите любую клавишу... ");
            Console.ReadKey(true);
        }

        private void PrintInfo()
        {
            Console.WriteLine("Вы пользуетесь программой для выода IP адресов с заданными параметрами");
            Console.WriteLine();
            Console.WriteLine("Обязательные парaметры:");
            Console.WriteLine("\t--file-log — файл с логами");
            Console.WriteLine("\t--file-output — файл, в который необходимо сохранить результаты");
            Console.WriteLine("\t--time-start —  нижняя граница временного интервала в формате dd.MM.yyyy");
            Console.WriteLine("\t--time-end — верхняя граница временного интервала в формате dd.MM.yyyy");
            Console.WriteLine();
            Console.WriteLine("Необязательные параметры:");
            Console.WriteLine("\t--address-start — нижняя граница диапазона адресов");
            Console.WriteLine("\t--address-mask — маска подсети, задающая верхнюю границу диапазона десятичное число. Нельзя использовать без --address-start");
            Console.WriteLine();
        }
    }
}
