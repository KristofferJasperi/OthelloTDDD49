﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Othello
{
    /// <summary>
    /// Interaction logic for BoardControl.xaml
    /// </summary>
    public partial class BoardControl : UserControl
    {
        private Board m_board;
        public ObservableCollection<ObservableCollection<GUIField>> Rows { get; private set; }
        public bool ShowValidMoves { get; set; }

        public BoardControl()
        {
            ShowValidMoves = true;
            InitializeComponent();
        }

        /// <summary>
        /// Sets the board that should be shown in the GUI.
        /// 
        /// TODO: Remove listener for old board.
        /// </summary>
        public void SetBoard(Board board)
        {
                Rows = new ObservableCollection<ObservableCollection<GUIField>>();
                m_board = board;

                //Listen for new board
                m_board.BoardChanged += BoardChanged;

                for (int row = 0; row < m_board.Size; row++)
                {
                    var columns = new ObservableCollection<GUIField>();
                    for (int col = 0; col < m_board.Size; col++)
                    {
                        var coords = new Coords(col, row);
                        var field = new GUIField(board.GetFieldValue(coords), coords);
                        columns.Add(field);
                    }

                    Rows.Add(columns);
                }

                this.DataContext = Rows;
        }

        public void UpdateHighlights(FieldValue color)
        {
            var validMoves = OthelloRules.GetValidMovesForColor(color, m_board);
            
            foreach (var column in Rows)
            {
                foreach (var field in column)
                {
                    if (ShowValidMoves && validMoves.Contains(field.Coords))
                    {
                        field.BackgroundColor.Opacity = 0.4;
                    }
                    else
                    {
                        field.BackgroundColor.Opacity = 0.0;
                    }
                }
            }
        }


        private void BoardChanged(Coords coords, FieldValue value)
        {
            if (Rows != null)
            {
                Rows[coords.Y][coords.X].Value = value;
            }
        }

        private void BoardClicked(object sender, MouseEventArgs e)
        {
            BoardClickedEvent(sender, e);
        }

        public event MouseEventHandler BoardClickedEvent;
    }
}
