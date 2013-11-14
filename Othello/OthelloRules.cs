using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Othello
{
    public class OthelloRules
    {
        public const int left = -1;
        public const int right = -1;
        public const int none = 0; 
        
        public const int up = -1;
        public const int down = 1;


        private static bool IsDirectionValid(ref Move move, ref IBoardReader board, int horDir, int vertDir)
        {
            int size = board.Size;
            int x = move.Column;
            int y = move.Row;
            FieldValue color = move.Color;
            FieldValue oppositeColor = color == FieldValue.White ? FieldValue.Black : FieldValue.White;

            if (color == FieldValue.Empty)
            {
                return false;
            }

            if (board.GetFieldValue(y + horDir, x + vertDir) != oppositeColor)
            {
                return false;
            }

            x += 2 * vertDir;
            y += 2 * horDir;

            while(x <= size && y <= size && x >= 0 && y >= 0)
            {
                if (board.GetFieldValue(y, x) == FieldValue.Empty)
                {
                    return false;
                }
                if (board.GetFieldValue(y, x) == FieldValue.Black)
                {
                    return true;
                }
                x += vertDir;
                y += horDir;
            }
            return false;
        }


        public static bool IsValidMove(ref Move move, ref IBoardReader board)
        {

            if (IsDirectionValid(ref move, ref board, left, up))
            {
                return true;
            }
            if (IsDirectionValid(ref move, ref board, left, down))
            {
                return true;
            }
            if (IsDirectionValid(ref move, ref board, left, none))
            {
                return true;
            }

            if (IsDirectionValid(ref move, ref board, right, up))
            {
                return true;
            }
            if (IsDirectionValid(ref move, ref board, right, down))
            {
                return true;
            }
            if (IsDirectionValid(ref move, ref board, right, none))
            {
                return true;
            }

            return false;
        }

        public static List<Coords> GetValidMovesForColor(FieldValue color)
        {
            throw new NotImplementedException();
        }

        public static bool IsGameOver()
        {
            throw new NotImplementedException();
        }
    }
}
