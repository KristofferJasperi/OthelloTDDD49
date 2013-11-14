using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Othello
{
    /// <summary>
    /// 
    /// </summary>
    public enum MoveType
    {
        AddPiece,
        Pass,
        Error
    }

    /// <summary>
    /// Represents a move. Contains a  move type,
    /// a color, and the coordinates.
    /// </summary>
    public class Move
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public MoveType Type { get; set; }
        public FieldValue Color { get; set; }

        public Move(int col, int row, MoveType type, FieldValue color)
        {
            Column = col;
            Row = row;
            Type = type;
            Color = color;
            
        }
    }

    /// <summary>
    /// Abstract class for a PlayerController.
    /// </summary>
    public interface IPlayerController
    {
        /// <summary>
        /// Returns the next move from this controller. 
        /// </summary>
        Move GetNextMove();
    }

    /// <summary>
    /// Implements a local controller.
    /// </summary>
    public class LocalController : IPlayerController
    {
        public List<Move> MovesToMake { get; set; }

        /// <summary>
        /// Gets the next move by listening for a move event.
        /// </summary>
        public Move GetNextMove()
        {
            throw new NotImplementedException();
        }
    }

    public class AIController : IPlayerController
    {
        /// <summary>
        /// Get the next move by calculating the best move.
        /// </summary>
        public Move GetNextMove()
        {
            throw new NotImplementedException();
        }
    }
}
