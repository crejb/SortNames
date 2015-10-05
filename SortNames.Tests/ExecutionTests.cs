using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SortNames.Interfaces;
using System.Collections.Generic;

namespace SortNames.Tests
{
    [TestClass]
    public class ExecutionTests
    {
        [TestMethod]
        public void IntegrationTest()
        {
            var unsortedPeople = new List<Person>
            {
                new Person("BFirst", "BLast"),
                new Person("AFirst", "ALast")
            };

            var sortedPeople = new List<Person>
            {
                new Person("AFirst", "ALast"),
                new Person("BFirst", "BLast")
            };

            // Arrange
            var dataSource = Substitute.For<IPersonDataSource>();
            dataSource.GetPeople().Returns(unsortedPeople);

            var sortStrategy = Substitute.For<ISortStrategy>();
            sortStrategy.Sort(unsortedPeople).Returns(sortedPeople);

            var displayer = Substitute.For<IPeopleDisplayer>();
            
            // Act
            var execution = new SortNamesExecution(dataSource, sortStrategy, new IPeopleDisplayer[] { displayer });
            execution.Run();

            // Assert
            dataSource.Received().GetPeople();
            sortStrategy.Received().Sort(unsortedPeople);
            displayer.Received().DisplayPeople(sortedPeople);
        }

        [TestMethod]
        public void GivenMultipleDisplayers_ThenAllDisplayersAreTriggered()
        {
            var sortedPeople = new List<Person>
            {
                new Person("AFirst", "ALast"),
                new Person("BFirst", "BLast")
            };

            // Arrange
            var dataSource = Substitute.For<IPersonDataSource>();
            var sortStrategy = Substitute.For<ISortStrategy>();
            sortStrategy.Sort(Arg.Any<IEnumerable<Person>>()).Returns(sortedPeople);

            var displayer1 = Substitute.For<IPeopleDisplayer>();
            var displayer2 = Substitute.For<IPeopleDisplayer>();

            // Act
            var execution = new SortNamesExecution(dataSource, sortStrategy, new IPeopleDisplayer[] { displayer1, displayer2 });
            execution.Run();

            // Assert
            displayer1.Received().DisplayPeople(sortedPeople);
            displayer2.Received().DisplayPeople(sortedPeople);
        }
    }
}
