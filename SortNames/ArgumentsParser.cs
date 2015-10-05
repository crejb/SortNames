using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames
{
    public class ArgumentsParser
    {
        public bool Success { get; private set; }
        public string Filename { get; private set; }
        public string ErrorMessage { get; private set; }

        private readonly string[] _args;

        public ArgumentsParser(string[] args)
        {
            _args = args;

            Filename = string.Empty;
            ErrorMessage = string.Empty;
        }

        public void Parse()
        {
            Filename = string.Empty;
            ErrorMessage = string.Empty;

            if (_args.Length != 1)
            {
                ErrorMessage = "Invalid arguments. Usage: SortDemo.exe <filename>";
                Success = false;
                return;
            }

            var filenameArgument = _args[0];
            if (string.IsNullOrWhiteSpace(filenameArgument))
            {
                ErrorMessage = "Invalid arguments. Usage: SortDemo.exe <filename>";
                Success = false;
                return;
            }

            Filename = filenameArgument;
            Success = true;
        }
    }

}
