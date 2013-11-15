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
        private GUIBoard m_guiBoard;
        private Board m_board;
        private Player m_playerBlack;
        private Player m_playerWhite;
        private Player activePlayer;

        public OthelloGame(GUIBoard guiBoard)
        {
            m_guiBoard = guiBoard;
            m_board = new Board(m_guiBoard.Size);

            m_playerBlack = new Player() { Type = PlayerType.Player, Color = FieldValue.Black };
            m_playerWhite = new Player() { Type = PlayerType.Player, Color = FieldValue.White };

            activePlayer = m_playerBlack;
        }

        public void Restart()
        {
            m_board.SetStartValues();
            Update();
        }

        /// <summary>
        /// Flips one direction. Make sure the direction is a valid direction
        /// before flipping. Otherwise it will flip all pieces.
        /// 
        /// TODO: Should this method check if the direction is valid first?
        /// It propably should'nt because then we have to check the direction
        /// twice.
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
            FieldValue color = activePlayer.Color;

            var possibleDirection = OthelloRules.GetPossibleDirections(color, coords, m_board);


            if(possibleDirection.Count != 0)
            {
                foreach (var dir in possibleDirection)
                {
                    FlipDirection(color, coords, dir);
                }
                m_board.SetFieldValue(color, coords);

                Update();

                activePlayer = activePlayer == m_playerBlack ? m_playerWhite : m_playerBlack;
            }
        }

        private void Update()
        {
            m_guiBoard.Update(m_board.Fields);
        }
    }
}
