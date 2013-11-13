using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Othello
{
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
    }

    /// <summary>
    /// Abstract class for a PlayerController.
    /// </summary>
    public abstract class PlayerController
    {
        /// <summary>
        /// Returns the next move from this controller. 
        /// </summary>
        public abstract Move GetNextMove();
    }

    /// <summary>
    /// Implements a local controller.
    /// </summary>
    public class LocalController : PlayerController
    {
        /// <summary>
        /// Gets the next move by listening for a move event.
        /// </summary>
        public override Move GetNextMove()
        {
            throw new NotImplementedException();
        }
    }

    public class AIController : PlayerController
    {
        /// <summary>
        /// Get the next move by calculating the best move.
        /// </summary>
        public override Move GetNextMove()
        {
            throw new NotImplementedException();
        }
    }
}
