using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortNames.Interfaces;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace SortNames.Tests
{
    [TestClass]
    public class PeopleDisplayerToFileTests
    {
        [TestMethod]
        public void GivenNoPeople_ThenNoPeopleWrittenToFile()
        {
            // Arrange
            var formatter = Substitute.For<IPersonFormatter>();
            var fileWriter = Substitute.For<IFileWriter>();

            // Act
            var displayer = new PeopleDisplayerToFile(formatter, fileWriter);
            displayer.DisplayPeople(new Person[0]);

            // Assert
            fileWriter.Received().WriteData(
                Arg.Is<IEnumerable<string>>(data => !data.Any()));
        }

        [TestMethod]
        public void GivenPeople_ThenFormattedPeopleWrittenToFile()
        {
            // Arrange
            var people = new[]
            {
                new Person("AFirst", "ALast"),
                new Person("BFirst", "BLast")
            };

            var formatter = Substitute.For<IPersonFormatter>();
            formatter.FormatPerson(people[0]).Returns("ALast, AFirst");
            formatter.FormatPerson(people[1]).Returns("BLast, BFirst");

            var fileWriter = Substitute.For<IFileWriter>();

            // Act
            var displayer = new PeopleDisplayerToFile(formatter, fileWriter);
            displayer.DisplayPeople(people);

            // Assert
            var verifyDataCallback = new Func<IEnumerable<string>, bool>(data =>
            {
                var dataList = data.ToList();
                return dataList.Count == 2
                    && dataList[0] == "ALast, AFirst"
                    && dataList[1] == "BLast, BFirst";
            });

            fileWriter.Received().WriteData(
                Arg.Is<IEnumerable<string>>(data => verifyDataCallback(data)));
        }
    }
}
