using NUnit.Framework;

namespace ClassLibrary.UnitTests
{
    [TestFixture]
    public static class LibraryClassTest
    {
        [Test]
        public static void LibraryClassTest2()
        {
            Assert.AreEqual(LibraryClass.Sum(0, 0), 0);
            Assert.AreEqual(LibraryClass.Sum(0, 1), 1);
        }
    }
}
