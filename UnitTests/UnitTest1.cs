using NUnit.Framework;
using System.IO;
using Patron_test.Components;
using System.Reflection;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string dirpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Assert.Pass();
        }
    }
}