using SortNames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames
{
    public class PersonDataParser : IPersonDataParser
    {
        public Person ParsePerson(string personString)
        {
            if (string.IsNullOrWhiteSpace(personString))
            {
                return null;
            }

            var nameParts = personString.Split(',');
            if (nameParts.Length != 2)
            {
                return null;
            }

            return new Person(nameParts[1].Trim(), nameParts[0].Trim());
        }
    }
}
