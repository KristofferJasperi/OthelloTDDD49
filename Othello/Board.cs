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


        public void FlipPiece(FieldValue value, int row, int column)
        {
            if (!IsValidCoordinates(row, column))
            {
                throw new ArgumentOutOfRangeException("Row or column index out of range");
            }


        }
    }
}
