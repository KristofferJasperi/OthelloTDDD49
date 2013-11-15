using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public class Coords
    {
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            //Try cast
            var other = obj as Coords;
            if (other == null)
                return false;
            else
                return this.X == other.X && this.Y == other.Y;
        }

        public static Coords operator +(Coords a, Coords b)
        {
            return new Coords(a.X + b.X, a.Y + b.Y);
        }
    }
}
