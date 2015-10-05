using SortNames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames
{
    public class PeopleDisplayerToConsole : IPeopleDisplayer
    {
        private readonly IPersonFormatter _formatter;

        public PeopleDisplayerToConsole(IPersonFormatter formatter)
        {
            _formatter = formatter;
        }

        public bool DisplayPeople(IEnumerable<Person> people)
        {
            foreach (var person in people)
            {
                var personString = _formatter.FormatPerson(person);
                Console.WriteLine(personString);
            }
            return true;
        }
    }
}
