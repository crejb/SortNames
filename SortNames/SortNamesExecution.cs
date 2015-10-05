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
        private readonly IEnumerable<IPeopleDisplayer> _displayers;

        public SortNamesExecution(IPersonDataSource dataSource, ISortStrategy sortStrategy, IEnumerable<IPeopleDisplayer> displayers)
        {
            _dataSource = dataSource;
            _sortStrategy = sortStrategy;
            _displayers = displayers;
        }

        public void Run()
        {
            var people = _dataSource.GetPeople();
            var sortedPeople = _sortStrategy.Sort(people);
            foreach (var displayer in _displayers)
            {
                displayer.DisplayPeople(sortedPeople);
            }
        }
    }
}
