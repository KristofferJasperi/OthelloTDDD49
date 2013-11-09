using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public class Field
    {
        public int Value { get; set; }
        public Field(int value)
        {
            this.Value = value;
        }
    }
}
