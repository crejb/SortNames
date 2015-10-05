using SortNames.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames
{
    public class PersonFileWriter : IFileWriter
    {
        private readonly string _filename;
        private readonly ILogger _logger;

        public PersonFileWriter(string filename, ILogger logger)
        {
            _filename = filename;
            _logger = logger;
        }

        public bool WriteData(IEnumerable<string> data)
        {
            try
            {
                File.WriteAllLines(_filename, data.ToArray());
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogMessage(ex.Message);
                return false;
            }

            
        }
    }
}
