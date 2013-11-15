using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Othello;

namespace OthelloTest
{
    [TestClass]
    public class CoordsTest
    {
        [TestMethod]
        public void Equals_PositiveTest()
        {
            var c1 = new Coords(3, 4);
            var c2 = new Coords(3, 4);

            Assert.IsTrue(c1.Equals(c2));
        }

        [TestMethod]
        public void Equals_NegativeTest()
        {
            var c1 = new Coords(3, 4);
            var c2 = new Coords(3, 1);

            Assert.IsFalse(c1.Equals(c2));

            c1 = new Coords(2, 4);
            c2 = new Coords(3, 4);

            Assert.IsFalse(c1.Equals(c2));

            c1 = new Coords(2, 4);
            c2 = new Coords(3, 2);

            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod]
        public void AddOperator_Test()
        {
            var c1 = new Coords(3, 1);
            var c2 = new Coords(-1, 1);

            var c3 = c1 + c2;

            Assert.AreEqual(c3, new Coords(2, 2));
        }

        [TestMethod]
        public void IsInsideBoard_Test()
        {
            var c1 = new Coords(3, 4);
            Assert.IsTrue(c1.IsInsideBoard(8));
            Assert.IsFalse(c1.IsInsideBoard(4));

            c1 = new Coords(-1, 3);
            Assert.IsFalse(c1.IsInsideBoard(8));

            c1 = new Coords(1, -1);
            Assert.IsFalse(c1.IsInsideBoard(8));
        }
    }
}
