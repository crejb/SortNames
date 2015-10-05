using SortNames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames
{
    public class PeopleDisplayerToFile : IPeopleDisplayer
    {
        private readonly IPersonFormatter _formatter;
        private readonly IFileWriter _fileWriter;

        public PeopleDisplayerToFile(IPersonFormatter formatter, IFileWriter fileWriter)
        {
            _formatter = formatter;
            _fileWriter = fileWriter;
        }

        public bool DisplayPeople(IEnumerable<Person> people)
        {
            var peopleStrings = people.Select(person => _formatter.FormatPerson(person));
            return _fileWriter.WriteData(peopleStrings);
        }
    }
}
