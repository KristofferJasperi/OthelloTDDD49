using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Othello;

namespace OthelloTest
{
    [TestClass]
    public class OthelloRulesTest
    {
        [TestMethod]
        public void IsValidMove_Positive()
        {
            var board = new Board(8);

            board.SetFieldValue(FieldValue.Black, new Coords(0, 0));
            board.SetFieldValue(FieldValue.White, new Coords(1, 0));

            var valid = OthelloRules.IsValidMove(FieldValue.Black, new Coords(2, 0), board);
            Assert.IsTrue(valid);

            board.SetFieldValue(FieldValue.White, new Coords(1, 1));
            valid = OthelloRules.IsValidMove(FieldValue.Black, new Coords(2, 2), board);
            Assert.IsTrue(valid);


        }

        [TestMethod]
        public void FlipDirection()
        {
            var board = new Board(8);

            board.SetFieldValue(FieldValue.Black, new Coords(0, 0));
            board.SetFieldValue(FieldValue.White, new Coords(1, 0));

            var valid = OthelloRules.IsValidMove(FieldValue.Black, new Coords(2, 0), board);
            Assert.IsTrue(valid);

            board.SetFieldValue(FieldValue.White, new Coords(1, 1));
            valid = OthelloRules.IsValidMove(FieldValue.Black, new Coords(2, 2), board);
            Assert.IsTrue(valid);


        }
    }
}
