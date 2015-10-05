using SortNames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames
{
    public class SortNamesExecution
    {
        private readonly IPersonDataSource _dataSource;
        private readonly ISortStrategy _sortStrategy;
        private readonly IPeopleDisplayer _displayer;

        public SortNamesExecution(IPersonDataSource dataSource, ISortStrategy sortStrategy, IPeopleDisplayer displayer)
        {
            _dataSource = dataSource;
            _sortStrategy = sortStrategy;
            _displayer = displayer;
        }

        public void Run()
        {
            var people = _dataSource.GetPeople();
            var sortedPeople = _sortStrategy.Sort(people);
            _displayer.DisplayPeople(sortedPeople);
        }
    }
}
