using NUnit.Framework;

namespace ClassLibrary.UnitTests3
{
    [TestFixture]
    public static class LibraryClassTest
    {
        [Test]
        public static void LibraryClassTest1()
        {
            Assert.AreEqual(LibraryClass.Sum(0, 2), 2);
            Assert.AreEqual(LibraryClass.Sum(0, 3), 3);
        }
    }
}