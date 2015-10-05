using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortNames.Tests
{
    [TestClass]
    public class SortStrategyTests
    {
        [TestMethod]
        public void GivenZeroItems_ThenReturnsZeroItems()
        {
            var sorter = new LastNameSortStrategy();
            var sortedPeople = sorter.Sort(new Person[0]);

            Assert.AreEqual(0, sortedPeople.Count);
        }

        [TestMethod]
        public void GivenOneItem_ThenReturnsOneItem()
        {
            var person = new Person("AFirst", "ALast");

            var sorter = new LastNameSortStrategy();
            var sortedPeople = sorter.Sort(new[] { person });

            Assert.AreEqual(1, sortedPeople.Count);
            Assert.AreEqual(person, sortedPeople[0]);
        }

        [TestMethod]
        public void GivenUnsortedPeople_ThenPeopleAreSorted()
        {
            var personA = new Person("AFirst", "ALast");
            var personB = new Person("BFirst", "BLast");

            var sorter = new LastNameSortStrategy();
            var sortedPeople = sorter.Sort(new[] { personB, personA });

            Assert.AreEqual(2, sortedPeople.Count);
            Assert.AreEqual(personA, sortedPeople[0]);
            Assert.AreEqual(personB, sortedPeople[1]);
        }

        [TestMethod]
        public void GivenPeopleWithSameLastName_ThenPeopleAreSorted()
        {
            var personA = new Person("AFirst", "ALast");
            var personB = new Person("BFirst", "ALast");

            var sorter = new LastNameSortStrategy();
            var sortedPeople = sorter.Sort(new[] { personB, personA });

            Assert.AreEqual(2, sortedPeople.Count);
            Assert.AreEqual(personA, sortedPeople[0]);
            Assert.AreEqual(personB, sortedPeople[1]);
        }

        [TestMethod]
        public void IntegrationTest()
        {
            var person1 = new Person("THEODORE", "BAKER");
            var person2 = new Person("ANDREW", "SMITH");
            var person3 = new Person("MADISON", "KENT");
            var person4 = new Person("FREDRICK", "SMITH");

            var sorter = new LastNameSortStrategy();
            var sortedPeople = sorter.Sort(new[] { person1, person2, person3, person4 });

            Assert.AreEqual(4, sortedPeople.Count);
            Assert.AreEqual(person1, sortedPeople[0]);
            Assert.AreEqual(person3, sortedPeople[1]);
            Assert.AreEqual(person2, sortedPeople[2]);
            Assert.AreEqual(person4, sortedPeople[3]);
        }

        
    }
}
