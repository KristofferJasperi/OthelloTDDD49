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
    public class GUIBoard : INotifyPropertyChanged
    {
        private Board m_board;
        public int Size { get; private set; }
        
        public ObservableCollection<ObservableCollection<GUIField>> Rows { get; private set; }

        private void OnBoardChanged(Coords coords, FieldValue value)
        {
            Rows[coords.Y][coords.X].Value = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("CountBlacks"));
                PropertyChanged(this, new PropertyChangedEventArgs("CountWhites"));
            }
        }

        public GUIBoard(Board board)
        {
            Rows = new ObservableCollection<ObservableCollection<GUIField>>();
            Size = board.Size;
            m_board = board;

            m_board.BoardChanged += OnBoardChanged;

            for (int row = 0; row < Size; row++)
            {
                var columns = new ObservableCollection<GUIField>();
                for (int col = 0; col < Size; col++)
                {
                    var coords = new Coords(col, row);
                    var field = new GUIField(board.GetFieldValue(coords), coords);
                    columns.Add(field);
                }

                Rows.Add(columns);
            }
        }

        public int CountWhites
        {
            get
            {
                return m_board.CountWhites;
            }
        }

        public int CountBlacks
        {
            get
            {
                return m_board.CountBlacks;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
