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
<<<<<<< HEAD
        public IPlayerController Player1 { get; set; }
        public IPlayerController Player2 { get; set; }

        protected GUIBoard m_board;
        public GUIBoard GetBoard()
=======
        protected Board m_board;
        public Board GetBoard()
>>>>>>> Ändrade lite
        {
            return m_board;
        }

<<<<<<< HEAD
        public OthelloGame(GUIBoard board, IPlayerController player1, IPlayerController player2)
=======
        public OthelloGame(Board board)
>>>>>>> Ändrade lite
        {
            m_board = board;
        }

        public void Restart()
        {
            m_board.ClearBoard();
            m_board.SetStartValues();
        }
    }
}
