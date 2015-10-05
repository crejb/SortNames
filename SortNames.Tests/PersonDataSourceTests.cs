using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SortNames.Interfaces;
using System.Linq;

namespace SortNames.Tests
{
    [TestClass]
    public class PersonDataSourceTests
    {
        [TestMethod]
        public void IntegrationTest()
        {
            // Arrange
            var fileReader = Substitute.For<IFileReader>();
            fileReader.ReadData().Returns(new[] { "Line1", "Line2" });

            var parser = Substitute.For<IPersonDataParser>();
            parser.ParsePerson("Line1").Returns(new Person("AFirst", "ALast"));
            parser.ParsePerson("Line2").Returns(new Person("BFirst", "BLast"));

            // Act
            var dataSource = new PersonDataSource(fileReader, parser);
            var people = dataSource.GetPeople().ToList();

            // Assert
            Assert.AreEqual(2, people.Count);

            Assert.AreEqual(people[0].FirstName, "AFirst");
            Assert.AreEqual(people[0].LastName, "ALast");

            Assert.AreEqual(people[1].FirstName, "BFirst");
            Assert.AreEqual(people[1].LastName, "BLast");
        }
    }
}
