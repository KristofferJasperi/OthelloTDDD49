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

        /// <summary>
        /// Flips one direction. Make sure the direction is a valid direction
        /// before flipping. Otherwise it will flip all pieces.
        /// 
        /// TODO: Should this method check if the direction is valid first?
        /// It propably should'nt because then we have to check the direction
        /// twice.
        /// </summary>
        private static void FlipDirection(FieldValue color, Coords start, Coords dir, Board board)
        {
            Coords current = start + dir;
            FieldValue oppositeColor = color.OppositeColor();
            current += dir;
            FieldValue currentValue;
            while (current.IsInsideBoard(board.Size))
            {
                currentValue = board.GetFieldValue(current);
                if (currentValue == color || currentValue == FieldValue.Empty)
                {
                    break;
                }

                board.FlipPiece(current);
                current += dir;
             }
        }

        /// <summary>
        /// Jag la till lite hjälpsaker i Coords och color för att kunna
        /// göra koden mindre. Det minskade lite code metrics-värden,
        /// bla Cyclomatic Complexity och LOC.
        /// </summary>
        private static bool IsDirectionValid2(FieldValue color, Coords start, Coords dir, IBoardReader board)
        {
            bool isValid = false;
            Coords current = start + dir;            
            FieldValue oppositeColor = color.OppositeColor();

            //Make sure next is oppositecolor, otherwise move is invalid.
            if(current.IsInsideBoard(board.Size) && board.GetFieldValue(current) == oppositeColor)
            {
                current += dir;
                while(current.IsInsideBoard(board.Size))
                {
                    //Found one of ours, direction is valid, break
                    if (board.GetFieldValue(current) == color)
                    {
                        isValid = true;
                        break;
                    }
                    //Did not find one of ours, direction is invalid, break.
                    else if(board.GetFieldValue(current) == FieldValue.Empty)
                    {
                        break;
                    }
                    //Else, continue looking
                    current += dir;
                }
            }

            return isValid;
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
