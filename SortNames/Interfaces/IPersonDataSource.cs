using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames.Interfaces
{
    public interface IPersonDataSource
    {
        IEnumerable<Person> GetPeople();
    }
}
