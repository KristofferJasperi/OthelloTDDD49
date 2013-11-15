using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Othello;

namespace OthelloTest
{
    [TestClass]
    public class BoardTest
    {
        private Board m_board;

        [TestMethod]
        public void ClearBoard_PositiveTest()
        {
            m_board = new Board(8);
            m_board.SetFieldValue(FieldValue.Black, 2, 3);
            m_board.ClearBoard();
            var numNotEmpty = m_board.CountBlacks + m_board.CountWhites;
            Assert.AreEqual(0, numNotEmpty);
        }

        [TestMethod]
        public void SetStartValues_PositiveTest()
        {
            m_board = new Board(8);
            m_board.SetStartValues();
            Assert.AreEqual(2, m_board.CountWhites);
            Assert.AreEqual(2, m_board.CountBlacks);
            Assert.AreEqual(m_board.GetFieldValue(4,4), m_board.GetFieldValue(3, 3));
            Assert.AreEqual(m_board.GetFieldValue(3, 4), m_board.GetFieldValue(4, 3));
        }

        [TestMethod]
        public void CountByFieldValue_PositiveTest()
        {
            m_board = new Board(8);
            m_board.SetStartValues();
            m_board.SetFieldValue(FieldValue.Black, 0, 0);
            Assert.AreEqual(3, m_board.CountByFieldValue(FieldValue.Black));
            Assert.AreEqual(59, m_board.CountByFieldValue(FieldValue.Empty));
        }

        [TestMethod]
        public void FlipPiece_PositiveTest()
        {
            m_board = new Board(8);
            m_board.SetFieldValue(FieldValue.Black, 0, 0);
            m_board.FlipPiece(0, 0);
            Assert.AreEqual(FieldValue.White, m_board.GetFieldValue(0, 0));
        }

        [TestMethod]
        public void GetFieldValue_NegativeTest()
        {
            m_board = new Board(8);
            bool exceptionThrown = false;

            try { m_board.GetFieldValue(-1, 0); }
            catch (ArgumentOutOfRangeException) { exceptionThrown = true; }

            Assert.IsTrue(exceptionThrown);
            exceptionThrown = false;

            try { m_board.GetFieldValue(-1, -1); }
            catch (ArgumentOutOfRangeException) {exceptionThrown = true;}

            Assert.IsTrue(exceptionThrown);
            exceptionThrown = false;

            try { m_board.GetFieldValue(0, -1); }
            catch (ArgumentOutOfRangeException) { exceptionThrown = true; }

            Assert.IsTrue(exceptionThrown);
            exceptionThrown = false;

            try { m_board.GetFieldValue(8, 0); }
            catch (ArgumentOutOfRangeException) { exceptionThrown = true; }

            Assert.IsTrue(exceptionThrown);
            exceptionThrown = false;

            try { m_board.GetFieldValue(8, 8); }
            catch (ArgumentOutOfRangeException) { exceptionThrown = true; }

            Assert.IsTrue(exceptionThrown);
            exceptionThrown = false;

            try { m_board.GetFieldValue(0,8); }
            catch (ArgumentOutOfRangeException) { exceptionThrown = true; }

            Assert.IsTrue(exceptionThrown);
            exceptionThrown = false;

            try { m_board.GetFieldValue(8, -1); }
            catch (ArgumentOutOfRangeException) { exceptionThrown = true; }

            Assert.IsTrue(exceptionThrown);
            exceptionThrown = false;

            try { m_board.GetFieldValue(-1, 8); }
            catch (ArgumentOutOfRangeException) { exceptionThrown = true; }

            Assert.IsTrue(exceptionThrown);
        }
    }
}
