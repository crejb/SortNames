using SortNames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputFilename;
            if (!TryGetFilename(args, out inputFilename))
            {
                return;
            }

            var outputFilename = GetOutputFilename(inputFilename);

            var sortExecution = BuildSortExecution(inputFilename, outputFilename);

            if (!sortExecution.Run())
            {
                Console.WriteLine("Sort Names failed.");
                return;
            }

            Console.WriteLine("Finished: created {0}", outputFilename);
        }

        private static bool TryGetFilename(string[] args, out string filename)
        {
            var argumentParser = new ArgumentsParser(args);
            argumentParser.Parse();
            if (!argumentParser.Success)
            {
                Console.WriteLine(argumentParser.ErrorMessage);
                filename = null;
                return false;
            }

            filename = argumentParser.Filename;
            return true;
        }

        private static string GetOutputFilename(string filename)
        {
            var filenameProvider = new FilenameProvider();
            return filenameProvider.GetOutputFilename(filename);
        }

        private static SortNamesExecution BuildSortExecution(string inputFilename, string outputFilename)
        {
            var logger = new ConsoleLogger();
            var formatter = new PersonFormatter();
            var sortStrategy = new LastNameSortStrategy();

            var personFileReader = new PersonFileReader(inputFilename, logger);
            var personFileWriter = new PersonFileWriter(outputFilename, logger);

            var displayers = new IPeopleDisplayer[]
            {
                new PeopleDisplayerToFile(formatter, personFileWriter),
                new PeopleDisplayerToConsole(formatter)
            };

            var dataSource = new PersonDataSource(personFileReader, formatter);
            return new SortNamesExecution(dataSource, sortStrategy, displayers);
        }
    }
}
