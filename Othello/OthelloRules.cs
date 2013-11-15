using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



namespace Othello
{  
    public static class OthelloRules
    {   
        private static bool IsValidRange(int x, int y, int size)
        {
            return x >= 0 && x < size && y >= 0 && y < size;
        }

        private static bool IsDirectionValid(ref Move move, ref IBoardReader board, Coords direction)
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


        public static bool IsValidMove(Move move, IBoardReader board)
        {
            if (IsDirectionValid(ref move, ref board, Directions.Up))
            {
                return true;
            }
            if (IsDirectionValid(ref move, ref board, Directions.UpRight))
            {
                return true;
            }
            if (IsDirectionValid(ref move, ref board, Directions.Right))
            {
                return true;
            }            
            if (IsDirectionValid(ref move, ref board, Directions.DownRight))
            {
                return true;
            }
            if (IsDirectionValid(ref move, ref board, Directions.Down))
            {
                return true;
            }
            if (IsDirectionValid(ref move, ref board, Directions.DownLeft))
            {
                return true;
            } 
            
            if (IsDirectionValid(ref move, ref board, Directions.Left))
            {
                return true;
            }

            if (IsDirectionValid(ref move, ref board, Directions.UpLeft))
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
