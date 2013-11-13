using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public class OthelloGame : BoardLogic
    {
        public PlayerController Player1 { get; set; }
        public PlayerController Player2 { get; set; }

        private bool waitingForMove1;
        private bool waitingForMove2;

        public OthelloGame(Board board, PlayerController player1, PlayerController player2)
            : base(board)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public void Restart()
        {
            m_board.ClearBoard();
            m_board.SetStartValues();
        }

        protected override bool PlayTurn()
        {
            waitingForMove1 = true;
            var nextMove = Player1.GetNextMove();
            waitingForMove1 = false;
            m_board.SetValue(nextMove.Color, nextMove.Row, nextMove.Column);
            waitingForMove2 = true;
            nextMove = Player2.GetNextMove();
            waitingForMove2 = false;
            m_board.SetValue(nextMove.Color, nextMove.Row, nextMove.Column);
            return true;
        }
    }
}
