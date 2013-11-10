using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public abstract class BoardLogic
    {
        protected Board m_board;

        public BoardLogic(Board board)
        {
            m_board = board;
        }

        protected abstract bool PlayTurn();
        public void Run()
        {
            while (PlayTurn())
            { }
        }
    }
}
