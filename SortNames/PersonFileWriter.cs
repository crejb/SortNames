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

        public PersonFileWriter(string filename)
        {
            _filename = filename;
        }

        public void WriteData(IEnumerable<string> data)
        {
            File.WriteAllLines(_filename, data.ToArray());
        }
    }
}
