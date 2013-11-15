using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public enum FieldValue
    {
        Empty,
        Black,
        White
    }

    public static class FieldValueExtensions
    {
        public static FieldValue OppositeColor(this FieldValue value)
        {
            return value == FieldValue.White ? FieldValue.Black : FieldValue.White;
        }
    }
}
