using SortNames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames
{
    public class LastNameSortStrategy : ISortStrategy
    {
        public IList<Person> Sort(IEnumerable<Person> people)
        {
            return people.OrderBy(person => person.LastName)
                         .ThenBy(person => person.FirstName)
                         .ToList();
        }
    }
}
