using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public class Board
    {
        private FieldValue[,] m_fields;
        private int m_size;

        public Board(int size)
        {
            m_size = size;
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

        private bool IsValidCoordinates(int row, int column)
        {
            return row >= 0 && row < m_size && column >= 0 && column < m_size;
        }

        public FieldValue GetFieldValue(int row, int column)
        {
            if (!IsValidCoordinates(row, column))
            {
                throw new ArgumentOutOfRangeException("Row or column index out of range");
            }

            return m_fields[row, column];
        }

        public void SetFieldValue(FieldValue value, int row, int column)
        {
            if (!IsValidCoordinates(row, column)
            {
                throw new ArgumentOutOfRangeException("Row or column index out of range");
            }

            m_fields[row, column] = value;
        }

        public void FlipPiece(int row, int column)
        {
            if (!IsValidCoordinates(row, column))
            {
                throw new ArgumentOutOfRangeException("Row or column index out of range");
            }

            var value = m_fields[row, column];
            if (value != FieldValue.Black && value != FieldValue.White)
            {
                throw new ArgumentException("No piece to flip!");
            }

            m_fields[row, column] = value == FieldValue.Black ? 
                FieldValue.White : FieldValue.Black;
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

        /// <summary>
        /// Sets the starting field values
        /// </summary>
        public void SetStartValues()
        {
            int middle = m_size / 2;
            m_fields[middle - 1, middle - 1] = FieldValue.Black;
            m_fields[middle, middle] = FieldValue.Black;
            m_fields[middle - 1, middle] = FieldValue.White;
            m_fields[middle, middle - 1] = FieldValue.White;
        }
    }
}
