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
                    var field = new Field(row * size + col);
                    columns.Add(field);
                }

                Rows.Add(columns);
            }
        }
    }
}
