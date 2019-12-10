using NUnit.Framework;

namespace ClassLibrary.UnitTests4
{
    [TestFixture]
    public static class LibraryClassTest
    {
        [Test]
        public static void LibraryClassTest1()
        {
            Assert.AreEqual(LibraryClass.Sum(0, 3), 3);
            Assert.AreEqual(LibraryClass.Sum(0, 4), 4);
        }
    }
}