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

        public OthelloGame(ref GUIBoard guiBoard)
        {
            m_guiBoard = guiBoard;
            m_board = new Board(m_guiBoard.Size);
        }

        public void Restart()
        {
            m_board.SetStartValues();
            Update();
        }

        public void MakeMove(Move move)
        {
            m_board.SetFieldValue(move.Color, move.Row, move.Column);
            Update();
        }

        private void Update()
        {
            m_guiBoard.Update(m_board.Pieces);
        }
    }
}
