using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    /// <summary>
    /// The OthelloGame logic.
    /// </summary>
    public class OthelloGame : INotifyPropertyChanged
    {
        private IBoardWriter m_board;
        private Player m_playerBlack;
        private Player m_playerWhite;
        private Player m_activePlayer;
        public Player ActivePlayer
        {
            get
            {
                return m_activePlayer;
            }
            private set
            {
                if (m_activePlayer != value)
                {
                    m_activePlayer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public OthelloGame(IBoardWriter board)
        {
            m_board = board;
            m_playerBlack = new Player() { Type = PlayerType.Player, Color = FieldValue.Black };
            m_playerWhite = new Player() { Type = PlayerType.Player, Color = FieldValue.White };

            ActivePlayer = m_playerBlack;
        }

        public void Restart()
        {
            ActivePlayer = m_playerBlack;

            m_board.ClearBoard();
            m_board.SetStartValues();
        }

        /// <summary>
        /// Flips one direction. Make sure the direction is a valid direction
        /// before flipping. Otherwise it will flip all pieces.
        /// </summary>
        private void FlipDirection(FieldValue color, Coords start, Coords dir)
        {
            Coords current = start + dir;
            FieldValue oppositeColor = color.OppositeColor();
            FieldValue currentValue;
            while (current.IsInsideBoard(m_board.Size))
            {
                currentValue = m_board.GetFieldValue(current);
                if (currentValue == FieldValue.Empty)
                {
                    throw new InvalidOperationException("Tried to flip invalid direction.");
                }
                if (currentValue == color)
                {
                    break;
                }

                m_board.FlipPiece(current);
                current += dir;
            }
        }

        public bool MakeMove(MoveType type, Coords coords)
        {
            if (OthelloRules.IsValidMove(type, m_activePlayer.Color, coords, m_board))
            {
                if (type.Equals(MoveType.AddPiece))
                {
                    FieldValue color = m_activePlayer.Color;

                    var flipDirections = OthelloRules.GetPossibleDirections(color, coords, m_board);
                    foreach (var dir in flipDirections)
                    {
                        FlipDirection(color, coords, dir);
                    }
                    m_board.SetFieldValue(color, coords);
                }

                ToggleActivePlayer();
                return true;
            }

            return false;
        }

        private void ToggleActivePlayer()
        {
            ActivePlayer = ActivePlayer == m_playerBlack ? m_playerWhite : m_playerBlack;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
