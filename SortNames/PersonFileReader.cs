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

        public PersonFileReader(string filename)
        {
            _filename = filename;
        }

        public IEnumerable<string> ReadData()
        {
            return File.ReadLines(_filename);
        }
    }
}
