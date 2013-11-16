using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public interface IBoardReader
    {
        /// <summary>
        /// Gets the field value for given coords.
        /// </summary>
        FieldValue GetFieldValue(Coords coords);

        /// <summary>
        /// The size of the board.
        /// </summary>
        int Size {get;}
    }

    
    public class Board : IBoardReader
    {
        public FieldValue[,] Fields { get; private set; }
        public int Size { get; private set; }

        public Board(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Invalid board size", "size");
            }

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
        

        public FieldValue GetFieldValue(Coords coords)
        {
            if (!coords.IsInsideBoard(Size))
            {
                throw new ArgumentOutOfRangeException("Row or column index out of range");
            }

            return Fields[coords.Y, coords.X];
        }

        public void SetFieldValue(FieldValue value, Coords coords)
        {
            if (!coords.IsInsideBoard(Size))
            {
                throw new ArgumentOutOfRangeException("Row or column index out of range");
            }

            Fields[coords.Y, coords.X] = value;
        }


        public void FlipPiece(Coords coords)
        {
            if (!coords.IsInsideBoard(Size))
            {
                throw new ArgumentOutOfRangeException("Row or column index out of range");
            }

            var value = Fields[coords.Y, coords.X];
            if (value != FieldValue.Black && value != FieldValue.White)
            {
                throw new ArgumentException("No piece to flip!");
            }

            Fields[coords.Y, coords.X] = value.OppositeColor();
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
