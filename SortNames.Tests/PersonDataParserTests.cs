using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortNames.Tests
{
    [TestClass]
    public class PersonDataParserTests
    {
        [TestMethod]
        public void GivenValidInput_ThenParseSucceeds()
        {
            var parser = new PersonDataParser();
            var person = parser.ParsePerson("BAKER, THEODORE");
            Assert.AreEqual("THEODORE", person.FirstName);
            Assert.AreEqual("BAKER", person.LastName);
        }

        [TestMethod]
        public void GivenValidInputWithWhitespace_ThenWhitespaceIsStripped()
        {
            var parser = new PersonDataParser();
            var person = parser.ParsePerson(" BAKER ,  THEODORE  ");
            Assert.AreEqual("THEODORE", person.FirstName);
            Assert.AreEqual("BAKER", person.LastName);
        }

        [TestMethod]
        public void GivenValidInputWithNoFirstName_FirstNameIsEmpty()
        {
            var parser = new PersonDataParser();
            var person = parser.ParsePerson(", THEODORE");
            Assert.AreEqual("THEODORE", person.FirstName);
            Assert.AreEqual("", person.LastName);
        }

        [TestMethod]
        public void GivenValidInputWithNoLastName_LastNameIsEmpty()
        {
            var parser = new PersonDataParser();
            var person = parser.ParsePerson("BAKER, ");
            Assert.AreEqual("", person.FirstName);
            Assert.AreEqual("BAKER", person.LastName);
        }

        [TestMethod]
        public void InvalidInput_NullInput_Fails()
        {
            var parser = new PersonDataParser();
            var person = parser.ParsePerson(null);
            Assert.IsNull(person);
        }

        [TestMethod]
        public void InvalidInput_EmptyInput_Fails()
        {
            var parser = new PersonDataParser();
            var person = parser.ParsePerson("");
            Assert.IsNull(person);
        }

        [TestMethod]
        public void InvalidInput_SinglePart_Fails()
        {
            var parser = new PersonDataParser();
            var person = parser.ParsePerson("BAKER");
            Assert.IsNull(person);
        }

        [TestMethod]
        public void InvalidInput_MultipleParts_Fails()
        {
            var parser = new PersonDataParser();
            var person = parser.ParsePerson("BAKER, THEODORE, MORE");
            Assert.IsNull(person);
        }
    }
}
