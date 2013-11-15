using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public interface IBoardReader
    {
        FieldValue GetFieldValue(int row, int column);
        FieldValue GetFieldValue(Coords coords);
        int Size {get;}
    }
    
    public class Board : IBoardReader
    {
        public FieldValue[,] Fields { get; private set; }
        public int Size { get; private set; }

        public Board(int size)
        {
            Size = size;
            Fields = new FieldValue[size, size];
        }

        public int CountBlacks
        {
            get
            {
                return CountByFieldValue(FieldValue.Black);
            }
        }

        public int CountWhites
        {
            get
            {
                return CountByFieldValue(FieldValue.White);
            }
        }
        
        public FieldValue GetFieldValue(int row, int column)
        {
            if (!Coords.IsInsideBoard(row, column, Size))
            {
                throw new ArgumentOutOfRangeException("Row or column index out of range");
            }

            return Fields[row, column];
        }

        public FieldValue GetFieldValue(Coords coords)
        {
            return GetFieldValue(coords.X, coords.Y);
        }

        public void SetFieldValue(FieldValue value, int row, int column)
        {
            if (!Coords.IsInsideBoard(row, column, Size))
            {
                throw new ArgumentOutOfRangeException("Row or column index out of range");
            }

            Fields[row, column] = value;
        }

        public void FlipPiece(int row, int column)
        {
            if (!Coords.IsInsideBoard(row, column, Size))
            {
                throw new ArgumentOutOfRangeException("Row or column index out of range");
            }

            var value = Fields[row, column];
            if (value != FieldValue.Black && value != FieldValue.White)
            {
                throw new ArgumentException("No piece to flip!");
            }

            Fields[row, column] = value.OppositeColor();
        }

        public void FlipPiece(Coords coords)
        {
            FlipPiece(coords.X, coords.Y);
        }

        public int CountByFieldValue(FieldValue value)
        {
            int count = 0;
            foreach (var val in Fields)
            {
                if (val == value)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Sets the starting field values
        /// </summary>
        public void SetStartValues()
        {
            int middle = Size / 2;
            Fields[middle - 1, middle - 1] = FieldValue.Black;
            Fields[middle, middle] = FieldValue.Black;
            Fields[middle - 1, middle] = FieldValue.White;
            Fields[middle, middle - 1] = FieldValue.White;
        }

        public void ClearBoard()
        {
            for (int row = 0; row < Size; ++row)
            {
                for (int col = 0; col < Size; ++col)
                {
                    Fields[row, col] = FieldValue.Empty;
                }
            }
        }
    }
}
