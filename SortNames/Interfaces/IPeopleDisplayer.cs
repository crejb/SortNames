using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames.Interfaces
{
    public interface IPeopleDisplayer
    {
        void DisplayPeople(IEnumerable<Person> people);
    }
}
