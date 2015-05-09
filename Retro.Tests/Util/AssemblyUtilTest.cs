using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Retro.Domain.Util;

namespace Retro.Tests.Util
{
    [TestFixture]
    public class AssemblyUtilTest
    {
        [Test]
        public void ShouldFindEmbeddedResource() {
            var result = Assembly.GetExecutingAssembly().FindEmbeddedFile("test.txt");
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void ShouldReadEmbeddedFileContent() {
            var result = Assembly.GetExecutingAssembly().FindEmbeddedFile("test.txt");
            var content = Assembly.GetExecutingAssembly().ReadEmbeddedFile(result.First());
            Assert.AreEqual("Hello Test!", content);
        }
    }
}
