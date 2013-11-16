using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



namespace Othello
{  
    public static class OthelloRules
    {   
        /// <summary>
        /// </summary>
        private static bool IsDirectionValid(FieldValue color, Coords start, Coords dir, IBoardReader board)
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

        public static List<Coords> GetPossibleDirections(FieldValue color, Coords coords, IBoardReader board)
        {
            var possibleDirections = new List<Coords>();

            foreach (var direction in Directions.All)
            {
                if (IsDirectionValid(color, coords, direction, board))
                {
                    possibleDirections.Add(direction);
                }
            }

            return possibleDirections;
        }


        public static bool IsValidMove(FieldValue color, Coords coords, IBoardReader board)
        {
            foreach (var direction in Directions.All)
            {
                if (IsDirectionValid(color, coords, direction, board))
                {
                    return true;
                }
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
