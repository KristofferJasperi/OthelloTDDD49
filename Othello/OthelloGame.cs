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

        public void MakeMove(Move move)
        {
            move.Color = activePlayer.Color;
            move.Type = MoveType.AddPiece;

            if(OthelloRules.IsValidMove(move, m_board))
            {
                m_board.SetFieldValue(move.Color, move.Row, move.Column);
                Update();

                activePlayer = activePlayer == m_playerBlack ? m_playerWhite : m_playerBlack;
            }
        }

        private void Update()
        {
            m_guiBoard.Update(m_board.Pieces);
        }
    }
}
