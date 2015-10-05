using SortNames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames
{
    public class PersonFormatter : IPersonFormatter
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


        public string FormatPerson(Person person)
        {
            return string.Format("{0}, {1}", person.LastName, person.FirstName);
        }
    }
}
