using NUnit.Framework;

namespace ClassLibrary.UnitTests2
{
    [TestFixture]
    public static class LibraryClassTest
    {
        [Test]
        public static void LibraryClassTest1()
        {
            Assert.AreEqual(LibraryClass.Sum(0, 1), 1);
            Assert.AreEqual(LibraryClass.Sum(0, 2), 2);
        }
    }
}