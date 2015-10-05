using SortNames.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames
{
    public class PersonFileReader : IFileReader
    {
        private readonly string _filename;
        private readonly ILogger _logger;

        public PersonFileReader(string filename, ILogger logger)
        {
            _filename = filename;
            _logger = logger;
        }

        public IEnumerable<string> ReadData()
        {
            try
            {
                return File.ReadLines(_filename);
            }
            catch (Exception ex)
            {
                _logger.LogMessage(ex.Message);
                return null;
            }
        }
    }
}
