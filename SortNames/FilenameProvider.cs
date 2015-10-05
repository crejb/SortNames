using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames
{
    public class FilenameProvider
    {
        private const string SUFFIX = "sorted";
        private const string EXTENSION = "txt";

        public string GetOutputFilename(string inputFilename)
        {
            var filenameBase = Path.GetFileNameWithoutExtension(inputFilename);
            return string.Format("{0}-{1}.{2}", filenameBase, SUFFIX, EXTENSION);
        }
    }
}
