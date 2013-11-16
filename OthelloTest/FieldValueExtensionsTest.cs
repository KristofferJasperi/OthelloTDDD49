using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Othello;

namespace OthelloTest
{
    /// <summary>
    /// Summary description for FieldValueExtensionsTest
    /// </summary>
    [TestClass]
    public class FieldValueExtensionsTest
    {
        [TestMethod]
        public void OppositeColor_Test()
        {
            var value = FieldValue.Black;
            Assert.AreEqual(FieldValue.White, value.OppositeColor());

            value = FieldValue.White;
            Assert.AreEqual(FieldValue.Black, value.OppositeColor());
        }
    }
}
