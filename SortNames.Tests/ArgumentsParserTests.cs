using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortNames.Tests
{
    [TestClass]
    public class ArgumentsParserTests
    {
        [TestMethod]
        public void GivenZeroArguments_ThenParseFails()
        {
            // Arrange
            var parser = new ArgumentsParser(new string[0]);

            // Act
            parser.Parse();

            // Assert
            Assert.IsFalse(parser.Success);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parser.ErrorMessage), "Error message must be populated");
        }

        [TestMethod]
        public void GivenMultipleArguments_ThenParseFails()
        {
            // Arrange
            var parser = new ArgumentsParser(new[] { "one", "two" });

            // Act
            parser.Parse();

            // Assert
            Assert.IsFalse(parser.Success);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parser.ErrorMessage), "Error message must be populated");
        }

        [TestMethod]
        public void GivenOneNullArgument_ThenParseFails()
        {
            // Arrange
            var parser = new ArgumentsParser(new string [] { null });

            // Act
            parser.Parse();

            // Assert
            Assert.IsFalse(parser.Success);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parser.ErrorMessage), "Error message must be populated");
        }

        [TestMethod]
        public void GivenOneEmptyArgument_ThenParseFails()
        {
            // Arrange
            var parser = new ArgumentsParser(new string[] { "" });

            // Act
            parser.Parse();

            // Assert
            Assert.IsFalse(parser.Success);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parser.ErrorMessage), "Error message must be populated");
        }

        [TestMethod]
        public void GivenOneWhitespaceArgument_ThenParseFails()
        {
            // Arrange
            var parser = new ArgumentsParser(new string[] { " " });

            // Act
            parser.Parse();

            // Assert
            Assert.IsFalse(parser.Success);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parser.ErrorMessage), "Error message must be populated");
        }

        [TestMethod]
        public void GivenOneValidArgument_ThenParseSucceeds()
        {
            // Arrange
            var parser = new ArgumentsParser(new string[] { "one" });

            // Act
            parser.Parse();

            // Assert
            Assert.IsTrue(parser.Success);
            Assert.AreEqual("one", parser.Filename);
        }
    }
}
