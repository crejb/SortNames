using SortNames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames
{
    public class PersonDataSource : IPersonDataSource
    {
        private readonly IFileReader _fileReader;
        private readonly IPersonFormatter _parser;

        public PersonDataSource(IFileReader fileReader, IPersonFormatter parser)
        {
            _fileReader = fileReader;
            _parser = parser;
        }

        public IEnumerable<Person> GetPeople()
        {
            var data = _fileReader.ReadData();

            var people = new List<Person>();

            foreach (var personData in data)
            {
                var person = _parser.ParsePerson(personData);
                if (person != null)
                {
                    people.Add(person);
                }
            }

            return people;
        }
    }
}
