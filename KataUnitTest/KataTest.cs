using CodewarsKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataUnitTest
{
    [TestClass]
    public class KataTest
    {
        [TestMethod]
        public void One()
        {
            Assert.AreEqual("Thi1s is2 3a T4est", Kata.Order("is2 Thi1s T4est 3a"));
        }

        [TestMethod]
        public void Two()
        {
            Assert.AreEqual("Fo1r the2 g3ood 4of th5e pe6ople", Kata.Order("4of Fo1r pe6ople g3ood th5e the2"));
        }
        [TestMethod]
        public void Three()
        {
            Assert.AreEqual("", Kata.Order(""));
        }

        [TestMethod]
        public void FixedTest()
        {
            Assert.AreEqual("How Can Mirrors Be Real If Our Eyes Aren't Real",
                            "How can mirrors be real if our eyes aren't real".ToJadenCase(),
                            "Strings didn't match.");
        }

        [TestMethod]
        public void FindNextSquareTestOne() => Assert.AreEqual(144,
                            Kata.FindNextSquare(121),
                            "Expected is 144");


        [TestMethod]
        public void FindNextSquareTestTwo() => Assert.AreEqual(-1, Kata.FindNextSquare(155));
    }
}
