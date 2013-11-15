using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public static class Directions
    {
        public static readonly Coords Up = new Coords(0, -1);
        public static readonly Coords UpRight = new Coords(1, -1);
        public static readonly Coords Right = new Coords(1, 0);
        public static readonly Coords DownRight = new Coords(1, 1);
        public static readonly Coords Down = new Coords(0, 1);
        public static readonly Coords DownLeft = new Coords(-1, 1);
        public static readonly Coords Left = new Coords(-1, 0);
        public static readonly Coords UpLeft = new Coords(-1, -1);


        public static readonly List<Coords> All =
            new List<Coords> { Up, UpRight, Right, DownRight, Down, DownLeft, Left, UpLeft };
    }
}
