using ConsoleAppIpAdrress.Helpers;
using ConsoleAppIpAdrress.Models;
using ConsoleAppIpAdrress.Validators;
using System.Net;

namespace ConsoleAppIpAdrress.ArgsParses
{
    public class ArgsParser
    {
        private LogEntryOptions _entryOptions = new();
        private bool _isIpAddresIsSet;
        private bool _isMaskSet;
        public LogEntryOptions Parse(string[] arguments) 
        {
            for (int i = 1; i < arguments.Length; i++)
            {
                var arg = arguments[i];
                var nextArg = GetNextArgumentIfExists(arguments, i);

                switch (arg) 
                {
                    case "--file-log":
                        _entryOptions.LogPath = FileExistsHelper.Parse(nextArg, "--file-log");
                        i++;
                        break;
                    case "--file-output":
                        _entryOptions.OutputFilePath = nextArg;
                        i++;
                        break;
                    case "--address-start":
                        _entryOptions.AddressStart = IPAddresParseHelper.Parse(nextArg, "--address-start");
                        i++;
                        _isIpAddresIsSet = true;
                        break;
                    case "--address-mask":
                        _entryOptions.AddressMask = IPAddressMaskParseHelper.Parse(nextArg, "--address-mask");
                        i++;
                        _isMaskSet = true;
                        break;
                    case "--time-start":
                        _entryOptions.DateStart = DateParseHelper.Parse(nextArg, "--time-start");
                        i++;
                        break;
                    case "--time-end":
                        _entryOptions.DateEnd = DateParseHelper.Parse(nextArg, "--time-end").AddDays(1).AddMilliseconds(-1);
                        i++;
                        break;
                    default:
                        throw new ArgumentException($"непрвельный параметр {arg}");
                }
            }
            if (!_isIpAddresIsSet && _isMaskSet)
            {
                throw new ArgumentException($"нельзя использовать параметр --address-mask без --address-start");
            }

            return _entryOptions;
        }

        private string GetNextArgumentIfExists(string[] arguments, int currnetIndex)
        {
            var nextIndex = currnetIndex + 1;
            if (!(nextIndex < arguments.Length)) 
            {
                throw new ArgumentException("параметр не может быть пустым");
            }
            return arguments[nextIndex];
        }
    }
}
