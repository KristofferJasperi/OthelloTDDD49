using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public class GUIBoard
    {
        private Board m_board;
        public int Size { get; private set; }
        
        public ObservableCollection<ObservableCollection<Field>> Rows { get; set; }

      
        public void OnBoardChanged(Coords coords, FieldValue value)
        {
            Rows[coords.Y][coords.X].Value = value;
        }

        public GUIBoard(Board board)
        {
            Rows = new ObservableCollection<ObservableCollection<Field>>();
            Size = board.Size;
            m_board = board;

            m_board.BoardChanged += OnBoardChanged;

            for (int row = 0; row < Size; row++)
            {
                var columns = new ObservableCollection<Field>();
                for (int col = 0; col < Size; col++)
                {
                    var coords = new Coords(col, row);
                    var field = new Field(board.GetFieldValue(coords), coords);
                    columns.Add(field);
                }

                Rows.Add(columns);
            }
        }
    }
}
