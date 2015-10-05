using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortNames.Tests
{
    [TestClass]
    public class FilenameProviderTests
    {
        [TestMethod]
        public void GivenFileWithExtension_FilePrefixIsAdded()
        {
            var provider = new FilenameProvider();
            
            var outputFilename = provider.GetOutputFilename("input.txt");

            Assert.AreEqual("input-sorted.txt", outputFilename);
        }

        [TestMethod]
        public void GivenFileWithoutExtension_FilePrefixIsAdded()
        {
            var provider = new FilenameProvider();

            var outputFilename = provider.GetOutputFilename("input");

            Assert.AreEqual("input-sorted.txt", outputFilename);
        }
    }
}
