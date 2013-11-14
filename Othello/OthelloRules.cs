using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public class OthelloRules
    {
        public OthelloRules(Board board)
        {
        }

        public bool IsValidMove(Move move)
        {
            throw new NotImplementedException();
        }

        public void MakeMove(Move move)
        {
            throw new NotImplementedException();

        }

        public List<Coords> GetValidMovesForColor(FieldValue color)
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }
    }
}
