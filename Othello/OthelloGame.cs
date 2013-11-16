using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    /// <summary>
    /// The OthelloGame logic.
    /// </summary>
    public class OthelloGame
    {
        private IBoardWriter m_board;
        private Player m_playerBlack;
        private Player m_playerWhite;
        private Player m_activePlayer;

        public OthelloGame(IBoardWriter board)
        {
            m_board = board;
            m_playerBlack = new Player() { Type = PlayerType.Player, Color = FieldValue.Black };
            m_playerWhite = new Player() { Type = PlayerType.Player, Color = FieldValue.White };

            m_activePlayer = m_playerBlack;
        }

        public void Restart()
        {
            m_activePlayer = m_playerBlack;

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


        public void MakeMove(Coords coords)
        {
            FieldValue color = m_activePlayer.Color;

            var possibleDirection = OthelloRules.GetPossibleDirections(color, coords, m_board);


            if(possibleDirection.Count != 0)
            {
                foreach (var dir in possibleDirection)
                {
                    FlipDirection(color, coords, dir);
                }
                m_board.SetFieldValue(color, coords);

                ToggleActivePlayer();
            }
        }

        private void ToggleActivePlayer()
        {
            m_activePlayer = m_activePlayer == m_playerBlack ? m_playerWhite : m_playerBlack;
        }
    }
}
