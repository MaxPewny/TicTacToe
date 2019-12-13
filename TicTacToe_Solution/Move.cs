using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_Solution
{
    public struct Move
    {
        public int x { get; set; }
        public int y { get; set; }

        public Move(int pX, int pY) 
        {
            x = pX;
            y = pY;
        }

        public override String ToString()
        {
            return x + "|" + y;
        }
    }
}
