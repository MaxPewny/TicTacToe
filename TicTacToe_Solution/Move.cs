using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_Solution
{
    public struct Move
    {
        private int x;
        private int y;

        public Move(int pX, int pY) 
        {
            x = pX;
            y = pY;
        }

        public void SetX(int pX) 
        { 
            x = pX;
        }
        public void SetY(int pY)
        {
            y = pY;
        }

        public int GetX() 
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public override String ToString()
        {
            return x + "|" + y;
        }
    }
}
