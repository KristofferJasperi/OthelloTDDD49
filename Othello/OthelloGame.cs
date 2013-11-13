using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    /// <summary>
    /// The OthelloGame logic.
    /// 
    /// TODO: Needs refactoring, too many protected methods. Consider
    /// split up class into two classes.
    /// </summary>
    public class OthelloGame
    {
        public IPlayerController Player1 { get; set; }
        public IPlayerController Player2 { get; set; }

        protected Board m_board;
        public Board GetBoard()
        {
            return m_board;
        }

        public OthelloGame(Board board, IPlayerController player1, IPlayerController player2)
        {
            m_board = board;
            Player1 = player1;
            Player2 = player2;
        }

        public void Restart()
        {
            m_board.ClearBoard();
            m_board.SetStartValues();
        }

        /// <summary>
        /// Plays one turn.
        /// </summary>
        protected bool PlayTurn()
        {
            if (GameOver())
            {
                return false;
            }
            else
            {
                MakeMove(Player1);
            }


            if (GameOver())
            {
                return false;
            }
            else
            {
                MakeMove(Player2);
            }

            return true;
        }

        /// <summary>
        /// Gets the move from the given player. If the move is valid
        /// and the type is AddPiece, the piece is added and method
        /// returns true. If the move is a valid Pass, method just returns
        /// true. If the move is an error, method returns false.
        /// </summary>
        protected bool MakeMove(IPlayerController player)
        {
            bool validMove = false;
            Move nextMove = null;

            while (!validMove)
            {
                nextMove = player.GetNextMove();
                validMove = IsValidMove(nextMove);
            }
            if (nextMove.Type == MoveType.AddPiece)
            {
                m_board.SetValue(nextMove.Color, nextMove.Row, nextMove.Column);
            }
            else if (nextMove.Type == MoveType.Error)
            {
                return false;
            }

            //No error
            return true;
        }

        /// <summary>
        /// Checks end game conditions. I.e. if any player
        /// can make a move. Returns true if the game is over
        /// false otherwise.
        /// </summary>
        /// <returns></returns>
        protected bool GameOver()
        {
            throw new NotImplementedException();
        }

        protected bool IsValidMove(Move move)
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            while (PlayTurn())
            { }
        }
    }
}
