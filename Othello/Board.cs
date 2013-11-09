using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public class Board
    {
        public List<List<Field>> Rows { get; set; }

        public Board(int size)
        {
            Rows = new List<List<Field>>();
            for (int row = 0; row < size; row++)
            {
                var columns = new List<Field>();
                for (int col = 0; col < size; col++)
                {
                    var field = new Field(FieldValue.Empty, row, col);
                    if (col == 4)
                    {
                        field.Value = FieldValue.White;
                    }
                    else if (col == 5)
                    {
                        field.Value = FieldValue.Black;
                    }
                    columns.Add(field);
                }

                Rows.Add(columns);
            }
        }
    }
}
