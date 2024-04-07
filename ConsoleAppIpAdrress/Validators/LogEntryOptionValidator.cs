using ConsoleAppIpAdrress.Models;

namespace ConsoleAppIpAdrress.Validators
{
    public class LogEntryOptionValidator
    {
        public LogEntryOptions ValidateLogEntryOptions(LogEntryOptions logEntryOptions)
        {
            if (!IsRequiredParametersSet(logEntryOptions)) 
            {
                throw new ArgumentException("не установленны обязательные параметры");  
            }

            if(IsStartDateGreaterThanEndDate(logEntryOptions)) 
            {
                throw new ArgumentException("начальная дата не может быть больше конечной");
            }
            return logEntryOptions;
        }

        private bool IsRequiredParametersSet(LogEntryOptions logEntryOptions)
        {
            return (!string.IsNullOrEmpty(logEntryOptions.OutputFilePath) &&
                    !string.IsNullOrEmpty(logEntryOptions.LogPath) &&
                    DateTime.MinValue != logEntryOptions.DateStart &&
                    DateTime.MinValue != logEntryOptions.DateEnd);
        }
        private bool IsStartDateGreaterThanEndDate(LogEntryOptions logEntryOptions)
        {
            return logEntryOptions.DateStart > logEntryOptions.DateEnd;
        }
    }
}
