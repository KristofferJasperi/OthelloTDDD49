using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        /// Number of fields that contains a black piece.
        /// </summary>
        int CountBlacks {get;}

        /// <summary>
        /// Number of fields that contains a white piece.
        /// </summary>
        int CountWhites { get; }

        /// <summary>
        /// The size of the board. Total number if fields
        /// is size*size.
        /// </summary>
        int Size {get;}
    }

    public interface IBoardWriter : IBoardReader
    {
        /// <summary>
        /// Sets all fields value to empty.
        /// </summary>
        void ClearBoard();

        /// <summary>
        /// Sets start pieces.
        /// </summary>
        void SetStartValues();

        /// <summary>
        /// Sets a given field to a given value.
        /// </summary>
        void SetFieldValue(FieldValue value, Coords coords);

        /// <summary>
        /// Flips the piece at the given coordinates, if
        /// the field at those coordinates is empty, an
        /// exception is thrown.
        /// </summary>
        void FlipPiece(Coords coords);
    }

    
    public class Board : IBoardReader, IBoardWriter
    {
        private FieldValue[,] m_fields;
        public int Size { get; private set; }

        public Board(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Invalid board size", "size");
            }

            Size = size;
            m_fields = new FieldValue[size, size];
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

            return m_fields[coords.X, coords.Y];
        }

        public void SetFieldValue(FieldValue value, Coords coords)
        {
            if (!coords.IsInsideBoard(Size))
            {
                throw new ArgumentOutOfRangeException("Row or column index out of range");
            }
            if (m_fields[coords.X, coords.Y] != value)
            {
                m_fields[coords.X, coords.Y] = value;
                if (BoardChanged != null)
                {
                    BoardChanged(coords, value);
                }
            }
        }


        public void FlipPiece(Coords coords)
        {
            if (!coords.IsInsideBoard(Size))
            {
                throw new ArgumentOutOfRangeException("Row or column index out of range");
            }

            var value = m_fields[coords.X, coords.Y];
            if (value != FieldValue.Black && value != FieldValue.White)
            {
                throw new ArgumentException("No piece to flip!");
            }

            SetFieldValue(value.OppositeColor(), coords);
        }

        public int CountByFieldValue(FieldValue value)
        {
            int count = 0;
            foreach (var val in m_fields)
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
            SetFieldValue(FieldValue.Black, new Coords(middle - 1, middle - 1));
            SetFieldValue(FieldValue.Black, new Coords(middle, middle));
            SetFieldValue(FieldValue.White, new Coords(middle - 1, middle));
            SetFieldValue(FieldValue.White, new Coords(middle, middle - 1));
        }

        public void ClearBoard()
        {
            for (int x = 0; x < Size; ++x)
            {
                for (int y = 0; y < Size; ++y)
                {
                    SetFieldValue(FieldValue.Empty, new Coords(x, y));
                }
            }
        }

        public delegate void BoardChangedEventHandler(Coords coords, FieldValue value);
        public event BoardChangedEventHandler BoardChanged;
    }
}
