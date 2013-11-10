using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public class OthelloGame : BoardLogic
    {
        public OthelloGame(Board board)
            : base(board)
        {
        }

        public void Restart()
        {
            m_board.ClearBoard();
            m_board.SetStartValues();
        }

        protected override bool PlayTurn()
        {
            throw new NotImplementedException();
        }
    }
}
