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
            displayer.DisplayPeople(sortedPeople).Returns(true);
            
            // Act
            var execution = new SortNamesExecution(dataSource, sortStrategy, new IPeopleDisplayer[] { displayer });
            bool result = execution.Run();

            // Assert
            Assert.IsTrue(result);
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
            displayer1.DisplayPeople(Arg.Any<IEnumerable<Person>>()).Returns(true);
            
            var displayer2 = Substitute.For<IPeopleDisplayer>();
            displayer2.DisplayPeople(Arg.Any<IEnumerable<Person>>()).Returns(true);

            // Act
            var execution = new SortNamesExecution(dataSource, sortStrategy, new IPeopleDisplayer[] { displayer1, displayer2 });
            var result = execution.Run();

            // Assert
            Assert.IsTrue(result);
            displayer1.Received().DisplayPeople(sortedPeople);
            displayer2.Received().DisplayPeople(sortedPeople);
        }

        [TestMethod]
        public void WhenDisplayerFails_ThenExecutionFails()
        {
            // Arrange
            var dataSource = Substitute.For<IPersonDataSource>();
            var sortStrategy = Substitute.For<ISortStrategy>();

            var displayer = Substitute.For<IPeopleDisplayer>();
            displayer.DisplayPeople(Arg.Any<IEnumerable<Person>>()).Returns(false);

            // Act
            var execution = new SortNamesExecution(dataSource, sortStrategy, new IPeopleDisplayer[] { displayer });
            var result = execution.Run();

            // Assert
            displayer.ReceivedWithAnyArgs().DisplayPeople(null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenDataSourceFails_ThenExecutionFails()
        {
            // Arrange
            var dataSource = Substitute.For<IPersonDataSource>();
            dataSource.GetPeople().Returns((IEnumerable<Person>)null);
            var sortStrategy = Substitute.For<ISortStrategy>();
            var displayer = Substitute.For<IPeopleDisplayer>();

            // Act
            var execution = new SortNamesExecution(dataSource, sortStrategy, new IPeopleDisplayer[] { displayer });
            var result = execution.Run();

            // Assert
            sortStrategy.DidNotReceiveWithAnyArgs().Sort(null);
            displayer.DidNotReceiveWithAnyArgs().DisplayPeople(null);
            Assert.IsFalse(result);
        }
    }
}
