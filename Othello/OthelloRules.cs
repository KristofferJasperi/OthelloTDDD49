using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



namespace Othello
{
    public struct Direction
    {
        private readonly int x;
        private readonly int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Direction(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    };
    

    public static class OthelloRules
    {

        private static Direction left = new Direction(-1, 0);
        private static Direction right = new Direction(1, 0);
        private static Direction up = new Direction(0, -1);
        private static Direction down = new Direction(0, 1);

        private static Direction leftUp = new Direction(-1, -1);
        private static Direction leftDown = new Direction(-1, 1);
        private static Direction rightUp = new Direction(1, -1);
        private static Direction rightDown = new Direction(1, 1);
     

        private static bool IsValidRange(int x, int y, int size)
        {
            return x >= 0 && x < size && y >= 0 && y < size;
        }
        private static bool IsDirectionValid(ref Move move, ref IBoardReader board, Direction direction)
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

            if (!IsValidRange(x + direction.X, y + direction.Y, board.Size))
            {
                return false;
            }

            if (board.GetFieldValue(y + direction.Y, x + direction.X) != oppositeColor)
            {
                return false;
            }

            x += 2 * direction.X;
            y += 2 * direction.Y;

            while(IsValidRange(x, y, board.Size))
            {
                if (board.GetFieldValue(y, x) == FieldValue.Empty)
                {
                    return false;
                }
                if (board.GetFieldValue(y, x) == move.Color)
                {
                    return true;
                }
                x += direction.X;
                y += direction.Y;


            }

            return false;
        }


        public static bool IsValidMove(ref Move move, IBoardReader board)
        {
            if (IsDirectionValid(ref move, ref board, leftUp))
            {
                return true;
            }
            if (IsDirectionValid(ref move, ref board, leftDown))
            {
                return true;
            }
            if (IsDirectionValid(ref move, ref board, left))
            {
                return true;
            }            
            if (IsDirectionValid(ref move, ref board, rightUp))
            {
                return true;
            }
            if (IsDirectionValid(ref move, ref board, rightDown))
            {
                return true;
            }
            if (IsDirectionValid(ref move, ref board, right))
            {
                return true;
            } 
            
            if (IsDirectionValid(ref move, ref board, down))
            {
                return true;
            }

            if (IsDirectionValid(ref move, ref board, up))
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
